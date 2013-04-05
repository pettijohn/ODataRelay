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
            var svc = new RelayedODataService.DemoService(new Uri("http://localhost:63653/MyODataService.svc/"));

            var products = (from prod in svc.Products
                            select prod);

            foreach (var prod in products)
            {
                Console.WriteLine(prod.Name);
            }
        
        
        }
    }
}
