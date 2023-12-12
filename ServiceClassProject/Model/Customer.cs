using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

public class Customer
{
    // A static variable to keep track of the next available ID for auto-incrementing.
    private static int autoIncrement;

    // Property to represent the unique identifier of a Customer.
    // This property is auto-incremented, providing a unique ID for each customer.
    public int Id { get; set; }

    // Property to represent the username of a Customer.
    public string Username { get; set; }

    // Property to represent the password of a Customer.
    public string Password { get; set; }

    // Property to represent the first name of a Customer.
    public string FirstName { get; set; }

    // Property to represent the last name of a Customer.
    public string LastName { get; set; }

    // New property to track incentive points for the customer.
    public int IncentivePoints { get; private set; }

    // Constructor for the Customer class.
    // Increments the autoIncrement counter and assigns the current value to the customer's ID.
    public Customer()
    {
        autoIncrement++;
        Id = autoIncrement;
        // Initialize incentive points to 0 when a new customer is created.
        IncentivePoints = 5;
    }
    // Method to award incentive points to the customer based on the number of bookings made.
    public void AwardIncentivePoints(int numberOfBookings)
    {
        
        int pointsToAward = (numberOfBookings) * 5;

        // Increment the incentive points for the customer.
        IncentivePoints += pointsToAward;

       


    }
    // Method to retrieve the current incentive points for the customer.
    public int GetIncentivePoints()
    {
        return IncentivePoints;
    }
}
