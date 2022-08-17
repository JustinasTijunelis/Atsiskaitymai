using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class Tax
    {
        [Key]
        public string OrderId { get; set; }
        public string PropertyName { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public int Adults { get; set; }
        public string FeeName { get; set; }
        public decimal FeeAmount { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
        public List<Tax> Taxs { get; set; }

        public Tax() { }
        public Tax(string[] rawData)
        {
            OrderId = rawData[0].Trim('"'); 
            PropertyName = rawData[1].Trim('"');
            CheckIn = rawData[2].Trim('"');
            CheckOut = rawData[3].Trim('"');
            GuestFirstName = rawData[4].Trim('"');
            GuestLastName = rawData[5].Trim('"');
            Adults = Convert.ToInt32(rawData[6].Trim('"'));
            FeeName = rawData[8].Trim('"');
            FeeAmount = (0);//Convert.ToDecimal(rawData[9].Trim('"')); //Bookingo ateina iskarto su PVM
            PhoneNumber = rawData[10].Trim('"');
        }
        public Tax(string orderId, string propertyName, string checkIn, string checkOut, string guestFirstName,
            string guestLastName, int adults, string feeName, decimal feeAmount, string phoneNumber)
        {
            OrderId = orderId;
            PropertyName = propertyName;
            CheckIn = checkIn;
            CheckOut = checkOut;
            GuestFirstName = guestFirstName;
            GuestLastName = guestLastName;
            Adults = adults;
            FeeName = feeName;
            FeeAmount = feeAmount;
            PhoneNumber = phoneNumber;
        }
    }
}
