using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model
{
    public class LoginHandler
    {
        public static Account Run()
        {
            while (1 == 1)
            {
                Console.WriteLine("Input Username");
                string usernameInput = Console.ReadLine();
                Console.WriteLine("Input Password");
                string passwordInput = Console.ReadLine();

                if (Account.loginPairs[usernameInput] == passwordInput)
                {
                    return Account.accountList[usernameInput];
                }
                Console.Clear();
                Console.WriteLine("Username or Passowrd is Incorrect. Please Try Again");
            }


        }
    }
}
