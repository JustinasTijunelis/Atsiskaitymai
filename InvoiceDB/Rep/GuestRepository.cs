using InvoiceDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB.Rep
{
    public class GuestRepository
    {
        //private readonly InvoiceDBContext _dbContext;
        public List<Guest> Guests { get; set; }
        public GuestRepository()
        {
            Guests = new List<Guest>();

            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\Guest.csv");
            for (int i = 2; i < csvLines.Length; i++)
            {

                string[] rawData = csvLines[i].Split(',');
                if (string.IsNullOrEmpty(rawData[0]))
                {
                    break;
                }
                //_dbContext.Guests.Add(new Guest(rawData));
                //_dbContext.SaveChanges();
                //SystemService.CreateGuest(rawData);
                Guests.Add(new Guest(rawData)); //nuri buti Azure serverio add metodas
            }
        }
    }
}
