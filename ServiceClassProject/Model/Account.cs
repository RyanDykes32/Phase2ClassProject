using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

    public class Account
    {
    // Dictionary to store login credentials, where the key is the username and the value is the password.
    public static Dictionary<string, string> loginPairs = new Dictionary<string, string>(); // Key = Username, Value = Password

    // Dictionary to store user accounts, where the key is the username and the value is the associated Account object.
    public static Dictionary<string, Account> accountList = new Dictionary<string, Account>(); // Key = Username, Value = Account

    // Base class with protected fields for username and password, to be inherited by specific account types.
    protected string username;
    protected string password;

}
