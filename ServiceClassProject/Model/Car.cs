using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    // A class representing a car with basic information.
    public class Car
    {
        // Property to represent the name of an object.
        // This is a public property, allowing external access to the object's name.
        public string Name { get; set; }

        // Property to represent the price per hour of an object.
        // This is a public property, allowing external access to the object's price per hour.
        // The data type is decimal, suitable for representing monetary values.
        public decimal PricePerHour { get; set; }

    }
}



