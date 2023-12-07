using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

public class Booking
{
    private static int autoIncrement;
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationInHours { get; set; }
    public Car BookedCar { get; set; }
    public decimal TotalPrice => DurationInHours * BookedCar.PricePerHour;

    public Booking()
    {
        autoIncrement++;
        Id = autoIncrement;
    }
}
