using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    // A class representing a combination of customer and booking information.
    public class CustomerBooking
    {
        // Property to represent a Customer associated with a booking.
        // This property holds a reference to a Customer object.
        public Customer customer { get; set; }

        // Property to represent a Booking associated with a customer.
        // This property holds a reference to a Booking object.
        public Booking booking { get; set; }

        // Constructor for the CustomerBooking class.
        // Initializes the Customer and Booking properties with the provided parameters.
        public CustomerBooking(Customer c, Booking b)
        {
            // Assign the provided Customer to the customer property.
            customer = c;

            // Assign the provided Booking to the booking property.
            booking = b;
        }

    }
}
