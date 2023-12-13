using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

public class Booking
{
    // A static variable to keep track of the next available ID for auto-incrementing.
    private static int autoIncrement;

    // Property to represent the unique identifier of a Booking.
    // This property is auto-incremented, providing a unique ID for each booking.
    public int Id { get; set; }

    // Property to represent the start time of a Booking.
    // This property holds the date and time when the booking is scheduled to start.
    public DateTime StartTime { get; set; }

    // Property to represent the duration, in hours, of a Booking.
    // This property indicates how long the booking is scheduled to last.
    public int DurationInHours { get; set; }

    // Property to represent the Car that is booked for this Booking.
    // This property holds a reference to a Car object.
    public Car BookedCar { get; set; }

    // Property to calculate the total price of the Booking.
    // The total price is calculated based on the duration and the price per hour of the booked car.
    public decimal TotalPrice => DurationInHours * BookedCar.PricePerHour;

    // Constructor for the Booking class.
    // Increments the autoIncrement counter and assigns the current value to the booking's ID.
    public Booking()
    {
        autoIncrement++;
        Id = autoIncrement;
    }


}
