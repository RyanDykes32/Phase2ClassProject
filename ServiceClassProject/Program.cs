using ServiceClassProject.Model;

namespace ServiceClassProject;


    public class Program
    {
    // Main entry point of the program.
    public static void Main(string[] args)
    {
        // Create two Date objects representing start and end dates.
        Date d1 = new Date(1, 1, 2000);
        Date d2 = new Date(1, 7, 2000);

        // Create a Car object with specific details.
        Car c1 = new Car(0001, "Make1", "Model1", 1985, 24.50f);

        // Create two Customer objects with unique usernames and passwords.
        Customer cust1 = new Customer("Caleb", "passcode");
        Customer cust2 = new Customer("Jacob", "passcode2");

        // Run the login process to authenticate users.
        LoginHandler.Run();

        // Attempt to reserve the car for both customers during the specified date range.
        c1.ReserveCar(cust1, d1, d2);
        c1.ReserveCar(cust2, d1, d2);

        // Uncomment the line below if you want to print the schedule to the console.
        // Console.WriteLine(c1.schedule.ToString());
    }

}
