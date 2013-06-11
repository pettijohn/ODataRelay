using LocalClient.NorthwindRelay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new NorthwindRelay.NorthwindEntities(new Uri("https://webservicerelay.servicebus.windows.net/northwindrelay"));

            var customers = (from customer in svc.Customers
                             select customer).Take(10);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName);
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
