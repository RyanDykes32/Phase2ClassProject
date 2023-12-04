using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    public struct Date
    {
        private int month;
        private int day;
        private int year;

        public Date(int m, int d, int y)
        {
            month = m;
            day = d;
            year = y;
        }

        public int GetMonth()
        {
            return month;
        }

        public int GetDay()
        {
            return day;
        }

        public int GetYear()
        {
            return year;
        }

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

        public bool IsEqual(Date d)
        {
            return d.GetDay() == day && d.GetMonth() == month && d.GetYear() == year;
        }

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

        public void PrintDate()
        {
            Console.Write(month + "/" + day + "/" + year);

        }

        public void PrintDateLine()
        {
            Console.WriteLine(month + "/" + day + "/" + year);

        }

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

