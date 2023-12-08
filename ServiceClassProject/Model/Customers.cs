using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    // A class representing a collection of customers.
    public class Customers
    {
        // Property representing a list of Customer objects.
        // This property is used to store and manage a collection of customer data.
        public List<Customer> customers { get; set; }

        // Constructor for the Customers class.
        // Initializes the customers property as a new List<Customer> instance.
        public Customers()
        {
            customers = new List<Customer>();
        }

        // Method to authenticate a customer based on provided username and password.
        // Returns a Customer object if authentication is successful; otherwise, returns null.
        public Customer Authenticate(string username, string password)
        {
            // Use LINQ to find customers matching the provided username and password.
            var c = customers.Where(o => (o.Username == username) && (o.Password == password));

            // Check if any matching customers were found.
            if (c.Count() > 0)
            {
                // Return the first matching customer.
                return c.First();
            }
            else
            {
                // Return null if no matching customer is found.
                return null;
            }
        }

    }
}
    


