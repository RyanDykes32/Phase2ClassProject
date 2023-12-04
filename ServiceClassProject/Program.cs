using ServiceClassProject.Model;

namespace ServiceClassProject;


    internal class Program
    {
        public static void Main(string[] args)
        {
            Date d1 = new Date(1, 1, 2000);
            Date d2 = new Date(1, 7, 2000);

            Car c1 = new Car(0001, "Make1", "Model1", 1985, 24.50f);
            Customer cust1 = new Customer("Caleb", "passcode");
            Customer cust2 = new Customer("Jacob", "passcode2");

            LoginHandler.Run();

            c1.ReserveCar(cust1, d1, d2);
            c1.ReserveCar(cust2, d1, d2);
            //Console.WriteLine(c1.schedule.ToString());
        }
    }