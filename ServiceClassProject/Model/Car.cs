using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    public class Car
    {
        private static int uniqueLicenseNumber;

        private int licenseID;
        private string make;
        private string model;
        private int year;
        private float priceRate;
        public Dictionary<Date, Customer> schedule;

        public Car(int id, string ma, string mo, int y, float pr)
        {
            licenseID = id;
            make = ma;
            model = mo;
            year = y;
            priceRate = pr;
            schedule = new Dictionary<Date, Customer>();
        }

        public void ReserveCar(Customer c, Date start, Date end)
        {
            if (!CheckAvailability(start, end))
            {
                Console.WriteLine("Error: Attempt to Reserve Unavailable Block");
                return;
            }
            List<Date> list = Date.GetDatesBetween(start, end);
            foreach (var l in list)
            {
                schedule.Add(l, c);
            }

        }

        public bool CheckAvailability(Date start, Date end)
        {
            List<Date> list = Date.GetDatesBetween(start, end);
            foreach (var l in list)
            {
                if (schedule.ContainsKey(l))
                {
                    return false;
                }
            }

            return true;
        }






    }



}
