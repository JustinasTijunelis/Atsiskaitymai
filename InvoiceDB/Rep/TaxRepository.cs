using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB.Rep
{
    public class TaxRepository
    {
        //private readonly InvoiceDBContext _dbContext;
        public List<Tax> Taxs { get; set; }

        public TaxRepository()
        {
            Taxs = new List<Tax>();

            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\Tax.csv");
            for (int i = 2; i < csvLines.Length; i++)
            {

                string[] rawData = csvLines[i].Split(',');
                if (string.IsNullOrEmpty(rawData[0]))
                {
                    break;
                }

                //_dbContext.Taxs.Add(new Tax(rawData));
                //_dbContext.SaveChanges();
                Taxs.Add(new Tax(rawData)); // turi buti Azure add metodas 
            }
        }
        public decimal GetCityTax(string orderId, string name)
        {
            string airbnb = "Airbnb";
            string booking = "Booking";
            string kM = "Hostfully";

            if (name.Contains(airbnb))
            {
                var cityTaxByOrder = Taxs.FirstOrDefault(o => o.OrderId.Contains(orderId.Trim('"')) && o.FeeName.Contains("Tourist"));
                return Convert.ToDecimal(cityTaxByOrder.FeeAmount);
            }
            if (name.Contains(booking))
            {
                var itemRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return Convert.ToDecimal(itemRepository.Orders.Where(o => o.OrderId.Contains(orderId)).Sum(o => o.Nights * o.AdultsAmount));

            }
            if (name.Contains(kM))
            {
                var itemRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return Convert.ToDecimal(itemRepository.Orders.Where(o => o.OrderId.Contains(orderId)).Sum(o => o.Nights * o.AdultsAmount));

            }
            else
            {
                Console.WriteLine($"GetCityTax tokio Source nera - {name}");
                return 0;
            }
        }
        public decimal GetCleaningFee(string orderId, string name)
        {
            string airbnb = "Airbnb";
            string booking = "Booking";
            string kM = "Hostfully";

            if (name.Contains(airbnb))
            {
                var orderRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return Convert.ToDecimal(orderRepository.Orders.Where(o => o.OrderId.Contains(orderId)).Sum(o => o.CleaningFee * 1));
            }
            if (name.Contains(booking))
            {
                var orderRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return Convert.ToDecimal(orderRepository.Orders
                    .Where(o => o.OrderId.Contains(orderId)).Sum(o => o.CleaningFee / Convert.ToDecimal(1.09)));
            }
            if (name.Contains(kM))
            {
                var orderRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return Convert.ToDecimal(orderRepository.Orders.Where(o => o.OrderId.Contains(orderId))
                    .Sum(o => o.CleaningFee * 1));
            }
            else
            {
                Console.WriteLine($"GetCleaningFee tokio Source nera - {name}");
                return 0;
            }

        }
        public decimal GetVatTax(string orderId, string name)
        {
            string airbnb = "Airbnb";
            string booking = "Booking";
            string kM = "Hostfully";

            if (name.Contains(airbnb))
            {
                var cityTaxByOrder = Taxs.FirstOrDefault(o => o.OrderId.Contains(orderId.Trim('"')) && o.FeeName.Trim('"').Contains("VAT/GST"));

                if (cityTaxByOrder.FeeAmount == null)
                {
                    Console.WriteLine($" GetVatTax klaida  OrderID {cityTaxByOrder.OrderId}, {cityTaxByOrder.PropertyName} ");
                    return 0;
                }
                return Convert.ToDecimal(cityTaxByOrder.FeeAmount);
            }

            if (name.Contains(booking))
            {
                var orderRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return orderRepository.Orders.Where(o => o.OrderId.Contains(orderId))
                    .Sum(o => (o.CleaningFee - (o.CleaningFee / Convert.ToDecimal(1.09))) + ((o.RentAmount - (o.Nights * o.AdultsAmount)) / Convert.ToDecimal(1.09)));

            }
            if (name.Contains(kM))
            {
                var orderRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return orderRepository.Orders.Where(o => o.OrderId.Contains(orderId)).Sum(o => o.TaxAmount * 1);

            }
            else
            {
                Console.WriteLine($"GetVatTax tokio Source nera - {name}");
                return 0;
            }
        }
        public decimal GetRentAmount(string orderId, string name)
        {
            string airbnb = "Airbnb";
            string booking = "Booking";
            string kM = "Hostfully";

            if (name.Contains(airbnb))
            {
                var orderRepository = new OrderRepository();
                return Convert.ToDecimal(orderRepository.Orders.Where(o => o.OrderId.Contains(orderId)).Sum(o => o.RentAmount * 1));
            }

            else if (name.Contains(booking))
            {
                var orderRepository = new OrderRepository();
                return Convert.ToDecimal(orderRepository.Orders.Where(o => o.OrderId.Contains(orderId))
                .Sum(o => (o.RentAmount - (o.Nights * o.AdultsAmount)) / Convert.ToDecimal(1.09)));
            }
            else if (name.Contains(kM))
            {
                var orderRepository = new OrderRepository();
                //Console.WriteLine(orderId);
                return Convert.ToDecimal(orderRepository.Orders.Where(o => o.OrderId.Contains(orderId)).Sum(o => o.RentAmount * 1));
            }
            else
            {
                Console.WriteLine($"GetVatTax tokio Source nera - {name}");
                return 0;

            }
        }
    }
}
