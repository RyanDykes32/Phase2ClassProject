using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    public class Car
    { // Static variable to maintain a unique license number across all instances of Car objects.
        private static int uniqueLicenseNumber;

        // Instance variables representing the details of a car.
        private int licenseID;
        private string make;
        private string model;
        private int year;
        private float priceRate;

        // Dictionary to store the reservation schedule, mapping dates to customers.
        public Dictionary<Date, Customer> schedule;

        // Constructor for initializing a new Car object with provided details.
        public Car(int id, string ma, string mo, int y, float pr)
        {
            licenseID = id;
            make = ma;
            model = mo;
            year = y;
            priceRate = pr;
            schedule = new Dictionary<Date, Customer>();
        }

        // Method for reserving the car for a specific customer during a given date range.
        public void ReserveCar(Customer c, Date start, Date end)
        {
            // Check if the requested date range is available for reservation.
            if (!CheckAvailability(start, end))
            {
                Console.WriteLine("Error: Attempt to Reserve Unavailable Block");
                return;
            }

            // Generate a list of dates between the start and end dates.
            List<Date> list = Date.GetDatesBetween(start, end);

            // Add each date to the schedule, mapping it to the provided customer.
            foreach (var l in list)
            {
                schedule.Add(l, c);
            }
        }

        // Method for checking the availability of the car for a given date range.
        public bool CheckAvailability(Date start, Date end)
        {
            // Generate a list of dates between the start and end dates.
            List<Date> list = Date.GetDatesBetween(start, end);

            // Check if any date in the list is already reserved in the schedule.
            foreach (var l in list)
            {
                if (schedule.ContainsKey(l))
                {
                    return false; // Date is already reserved, car is not available.
                }
            }

            return true; // All dates in the range are available, car is available for reservation.
        }






    }



}
