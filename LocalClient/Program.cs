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
            var svc = new NorthwindRelay.NorthwindEntities(new Uri("http://localhost:63653/MyNorthwindService.svc/"));

            var customers = (from customer in svc.Customers
                             select customer).Take(10);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName);
            }
        }
    }
}
