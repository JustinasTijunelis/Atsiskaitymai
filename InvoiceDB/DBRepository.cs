using InvoiceDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class DBRepository
    {
        private readonly InvoiceDBContext _dbContext;
        public DBRepository()
        {
            _dbContext = new InvoiceDBContext();
        }
        public void AddGuest(Guest guest)
        {
            _dbContext.Guests.Add(guest);
        }
        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
        }
        public void AddTax(Tax tax)
        {
            _dbContext.Taxs.Add(tax);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
