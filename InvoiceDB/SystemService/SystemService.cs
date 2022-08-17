using InvoiceDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB.SystemService
{
    public class SystemService
    {
        private readonly DBRepository _repository;
        public SystemService()
        {
            _repository = new DBRepository();
        }
        public void CreateGuest(Guest guest)
        {
            _repository.AddGuest(guest);
            _repository.SaveChanges();

        }
    }
}
