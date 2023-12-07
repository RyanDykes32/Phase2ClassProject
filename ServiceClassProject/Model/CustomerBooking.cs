using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    public class CustomerBooking
    {
        public Customer customer { get; set; }
        public Booking booking { get; set; }

        public CustomerBooking(Customer c, Booking b)
        {
            customer = c;
            booking = b;
        }
    }
}
