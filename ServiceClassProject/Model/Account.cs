using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

    public class Account
    {
        public static Dictionary<string, string> loginPairs = new Dictionary<string, string>();//Key = Username, Value = Password
        public static Dictionary<string, Account> accountList = new Dictionary<string, Account>(); //Key = Username, Value = Account

        protected string username;
        protected string password;
    }
