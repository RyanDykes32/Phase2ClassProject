using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassProject.Model;

public class CustomerAppointment
{

    public Customer customer { get; set; }
    public Appointment appointment { get; set; }

    public CustomerAppointment(Customer c, Appointment a) 
    { 
    customer = c;
        appointment = a;

    }




}
