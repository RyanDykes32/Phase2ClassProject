using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

public class Customer : Account
{
    public Customer(string na, string pa)
    {
        username = na;
        password = pa;
        loginPairs.Add(username, password);
        accountList.Add(username, this);
    }
}
