using ServiceClassProject.Model;

namespace ServiceClassProject;


public class Program
{
    private static Customers customers;
    private static List<Booking> booking;
    private static List<CustomerBooking> customerbooking;
    private static Customer authenticatedCustomer;

    static void Main(string[] args)
    {
        Console.WriteLine("Initializing...");
        Initialize();
        Menu();
    }

    static void Initialize()
    {
        var c1 = new Customer
        {
            FirstName = "Ryan",
            LastName = "Dykes",
            Username = "Ryan",
            Password = "006189365"
        };
        var c2 = new Customer
        {
            FirstName = "Ben",
            LastName = "Jones",
            Username = "Ben",
            Password = "1234"
        };
        var b1 = new Booking();
        var b2 = new Booking();
        var b3 = new Booking();

        var ca1 = new CustomerBooking(c1, b1);
        var ca2 = new CustomerBooking(c1, b2);
        var ca3 = new CustomerBooking(c2, b3);

        customers = new Customers();
        customers.customers.Add(c1);
        customers.customers.Add(c2);

        booking = new List<Booking> { b1, b2, b3 };
        customerbooking = new List<CustomerBooking> { ca1, ca2, ca3 };
    }

    static void Menu()
    {
        bool done = false;

        while (!done)
        {
            Console.WriteLine("Options: Login: (1) --- Logout: (2) --- Sign Up: (3) --- Booking: (4) --- Cancel Booking: (5) --- Clear Screen: (c) --- Quit: (q)");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    LoginMenu();
                    break;
                case "2":
                    LogoutMenu();
                    break;
                case "3":
                    SignUpMenu();
                    break;
                case "4":
                    GetCurrentBookingMenu();
                    break;
                case "5":
                    CancelBookingMenu();
                    break;
                case "c":
                    Console.Clear();
                    break;
                case "q":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }
    }

    static void LoginMenu()
    {
        if (authenticatedCustomer == null)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            authenticatedCustomer = customers.Authenticate(username, password);
            if (authenticatedCustomer != null)
            {
                Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }
        else
        {
            Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");
        }
    }

    static void LogoutMenu()
    {
        authenticatedCustomer = null;
        Console.WriteLine("Logged out!");
    }

    static void SignUpMenu()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string LastName = Console.ReadLine();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        var newCustomer = new Customer
        {
            FirstName = firstName,
            LastName = LastName,
            Username = username,
            Password = password
        };

        customers.customers.Add(newCustomer);

        Console.WriteLine("Profile created!");
    }

    static void GetCurrentBookingMenu()
    {
        if (authenticatedCustomer == null)
        {
            Console.WriteLine("You are not logged in.");
            return;
        }

        var bookingList = customerbooking.Where(o => o.customer.Username == authenticatedCustomer.Username);

        if (bookingList.Count() == 0)
        {
            Console.WriteLine("No bookings found.");

            Console.Write("Do you want to make a new booking? (y/n): ");
            string response = Console.ReadLine();

            if (response.ToLower() == "y")
            {
                MakeNewBooking();
            }
        }
        else
        {
            Console.WriteLine("Current Bookings:");
            foreach (var booking in bookingList)
            {
                Console.WriteLine($"ID: {booking.booking.Id}, Date: {booking.booking.StartTime}, Car: {booking.booking.BookedCar.Name}, Duration: {booking.booking.DurationInHours} hours, Total Price: ${booking.booking.TotalPrice}");
            }
        }
    }

    static void CancelBookingMenu()
    {
        if (authenticatedCustomer == null)
        {
            Console.WriteLine("You are not logged in.");
            return;
        }

        var bookingList = customerbooking.Where(o => o.customer.Username == authenticatedCustomer.Username);

        if (bookingList.Count() == 0)
        {
            Console.WriteLine("No bookings found for cancellation.");
        }
        else
        {
            Console.WriteLine("Your Bookings:");
            foreach (var booking in bookingList)
            {
                Console.WriteLine($"ID: {booking.booking.Id}, Date: {booking.booking.StartTime}, Car: {booking.booking.BookedCar.Name}, Duration: {booking.booking.DurationInHours} hours, Total Price: ${booking.booking.TotalPrice}");
            }

            Console.Write("Enter the ID of the booking you want to cancel: ");
            if (int.TryParse(Console.ReadLine(), out int bookingId))
            {
                var bookingToCancel = bookingList.FirstOrDefault(b => b.booking.Id == bookingId);

                if (bookingToCancel != null)
                {
                    CancelBooking(bookingToCancel);
                }
                else
                {
                    Console.WriteLine("Invalid booking ID. Cancellation canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Cancellation canceled.");
            }
        }
    }

    static void CancelBooking(CustomerBooking bookingToCancel)
    {
        booking.Remove(bookingToCancel.booking);
        customerbooking.Remove(bookingToCancel);

        Console.WriteLine("Booking successfully canceled!");
    }

    static void MakeNewBooking()
    {
        Console.WriteLine("Available Cars:");
        Console.WriteLine("1. Car1 - $20 per hour");
        Console.WriteLine("2. Car2 - $25 per hour");
        Console.WriteLine("3. Car3 - $30 per hour");

        Console.Write("Enter the number of the car you want to book: ");
        if (int.TryParse(Console.ReadLine(), out int selectedCarNumber) && selectedCarNumber >= 1 && selectedCarNumber <= 3)
        {
            Car selectedCar = GetCarByNumber(selectedCarNumber);

            Console.Write("Enter the date and time for the new booking (e.g., '2023-12-31 14:30'): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime bookingDate))
            {
                Console.Write("Enter the duration of the booking in hours: ");
                if (int.TryParse(Console.ReadLine(), out int bookingDuration) && bookingDuration > 0)
                {
                    if (IsCarAvailable(selectedCar.Name, bookingDate, bookingDuration))
                    {
                        var newBooking = new Booking
                        {
                            StartTime = bookingDate,
                            DurationInHours = bookingDuration,
                            BookedCar = selectedCar
                        };

                        var newCustomerBooking = new CustomerBooking(authenticatedCustomer, newBooking);

                        booking.Add(newBooking);
                        customerbooking.Add(newCustomerBooking);

                        Console.WriteLine($"Booking for {selectedCar.Name} on {bookingDate} for {bookingDuration} hours successfully created!");
                        Console.WriteLine($"Total Price: ${newBooking.TotalPrice}");
                    }
                    else
                    {
                        Console.WriteLine($"The selected car '{selectedCar.Name}' is not available at the specified time.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid duration. Booking creation canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date and time format. Booking creation canceled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid car number. Booking creation canceled.");
        }
    }

    static Car GetCarByNumber(int carNumber)
    {
        switch (carNumber)
        {
            case 1:
                return new Car { Name = "Truck", PricePerHour = 20 };
            case 2:
                return new Car { Name = "SUV", PricePerHour = 25 };
            case 3:
                return new Car { Name = "Sedan", PricePerHour = 30 };
            default:
                return null;
        }
    }

    static bool IsCarAvailable(string selectedCar, DateTime bookingDate, int bookingDuration)
    {
        var existingBookingsForCar = booking.Where(b => b.BookedCar != null && b.BookedCar.Name == selectedCar);

        foreach (var existingBooking in existingBookingsForCar)
        {
            if (existingBooking.BookedCar != null)
            {
                var bookingEndTime = existingBooking.StartTime.AddHours(existingBooking.DurationInHours);

                // Check for any time overlap with existing bookings for the selected car
                if (bookingDate < bookingEndTime && bookingDate.AddHours(bookingDuration) > existingBooking.StartTime)
                {
                    return false; // The car is not available at the specified time
                }
            }
        }

        return true; // The car is available
    }

}