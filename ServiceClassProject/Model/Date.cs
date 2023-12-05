using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    // Struct representing a date with month, day, and year components.
    public struct Date
    {
        private int month;
        private int day;
        private int year;

        // Constructor to initialize a Date object with provided month, day, and year values.
        public Date(int m, int d, int y)
        {
            month = m;
            day = d;
            year = y;
        }

        // Method to get the month component of the date.
        public int GetMonth()
        {
            return month;
        }

        // Method to get the day component of the date.
        public int GetDay()
        {
            return day;
        }

        // Method to get the year component of the date.
        public int GetYear()
        {
            return year;
        }

        // Method to get the next day in the date sequence.
        public Date GetNextDay()
        {
            if (day < DateTime.DaysInMonth(year, month))
            {
                return new Date(month, day + 1, year);
            }
            if (month == 12)
            {
                return new Date(1, 1, year + 1);
            }
            else
            {
                return new Date(month + 1, 1, year);
            }
        }

        // Method to check if two dates are equal.
        public bool IsEqual(Date d)
        {
            return d.GetDay() == day && d.GetMonth() == month && d.GetYear() == year;
        }

        // Static method to get a list of dates between a start and end date.
        public static List<Date> GetDatesBetween(Date start, Date end)
        {
            List<Date> returnList = new List<Date>();
            for (Date d = start; !d.IsEqual(end); d = d.GetNextDay())
            {
                d.PrintDate();
                returnList.Add(d);
            }
            returnList.Add(end);
            return returnList;
        }

        // Method to print the date in the format: month/day/year.
        public void PrintDate()
        {
            Console.Write(month + "/" + day + "/" + year);
        }

        // Method to print the date in the format: month/day/year followed by a newline.
        public void PrintDateLine()
        {
            Console.WriteLine(month + "/" + day + "/" + year);
        }

        // Static method to print a list of dates.
        public static void PrintDates(List<Date> dl)
        {
            foreach (var d in dl)
            {
                d.PrintDate();
                Console.Write(" ,");
            }
        }
    }

}
       

