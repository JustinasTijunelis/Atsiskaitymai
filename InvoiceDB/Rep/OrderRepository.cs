using InvoiceDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB.Rep
{
    public class OrderRepository
    {
        //private readonly InvoiceDBContext _dbContext;
        public List<Order> Orders { get; set; }
        //public List<Tax> Taxs { get; set; }
        //public List<Guest> Guests { get; set; }
        public OrderRepository()
        {
            Orders = new List<Order>();

            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\Booking1.csv");
            for (int i = 2; i < csvLines.Length; i++)
            {

                string[] rawData = csvLines[i].Split(',');
                if (string.IsNullOrEmpty(rawData[0]))
                {
                    break;
                }
                //_dbContext.Orders.Add(new Order(rawData));
                //_dbContext.SaveChanges();
                Orders.Add(new Order(rawData)); //nuri buti Azure serverio add metodas
            }
        }
       
    }
}
