using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    public class LoginHandler
    {
        // Static method for running a login process and returning the associated Account.
        public static Account Run()
        {
            // Infinite loop for continuous login attempts until successful.
            while (1 == 1)
            {
                // Prompt user to input username.
                Console.WriteLine("Input Username");
                string usernameInput = Console.ReadLine();

                // Prompt user to input password.
                Console.WriteLine("Input Password");
                string passwordInput = Console.ReadLine();

                // Check if the entered username and password match a stored login pair.
                if (Account.loginPairs.ContainsKey(usernameInput) && Account.loginPairs[usernameInput] == passwordInput)
                {
                    // If match found, return the associated Account.
                    return Account.accountList[usernameInput];
                }

                // Clear the console and inform the user that the username or password is incorrect.
                Console.Clear();
                Console.WriteLine("Username or Password is Incorrect. Please Try Again");
            }
        }

    }


}
    
