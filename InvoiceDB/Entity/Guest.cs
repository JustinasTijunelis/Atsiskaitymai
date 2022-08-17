using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace InvoiceDB.Entity
{
    
    public class Guest
    {
        [Key]
        public string OrderId { get; set; } 
        public string PropertyName { get; set; }
        public int Nights { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string GuestEmail { get; set; }
        public string GuestCountry { get; set; }
        public List<Order> Orders { get; set; }
        public List<Tax> Taxs { get; set; }
        public Guest() { }
        public Guest(string[] rawData)
        {
            OrderId = rawData[0].Trim('"');
            PropertyName = rawData[2].Trim('"');
            Nights = Convert.ToInt32(rawData[4].Trim('"'));
            GuestFirstName = rawData[7].Trim('"');
            GuestLastName = rawData[8].Trim('"');
            PhoneNumber = rawData[9].Trim('"');
            Adults = Convert.ToInt32(rawData[10].Trim('"'));
            Children = Convert.ToInt32(rawData[11].Trim('"'));
            GuestEmail = rawData[12].Trim('"');

        }
        public Guest(string orderId, string propertyName, int night, string guestFirstName, string guestLastName, string phoneNumber,
            int adults, int children, string guestEmail, string guestCounty)
        {
            OrderId = orderId;
            PropertyName = propertyName;
            Nights = night;
            GuestFirstName = guestFirstName;
            GuestLastName = guestLastName;
            PhoneNumber = phoneNumber;
            Adults = adults;
            Children = children;
            GuestEmail = guestEmail;
            GuestCountry = guestCounty;
        }

        //public void CountryFromPhone()
        //{
        //    string swissNumberStr = "37061853881";
        //    Int32 number = 37061853881;
        //    var nrCountry = PhoneNumbers.PhoneNumberUtil.GetRegionCodeForNumber();
        //    Console.WriteLine(nrCountry);
        //    PhoneNumberUtil phoneUtil = GetRegionCodeForNumber(swissNumberStr);

            //try
            //{
            //    PhoneNumber swissNumberProto = phoneUtil.Parse(swissNumberStr, "CH");
            //}
            //catch (NumberParseException e)
            //{
            //    System.ArgumentNullException("NumberParseException was thrown: " + e.ToString());
            //}

            //try
            //{
            //    // phone must begin with '+'
            //    PhoneNumber numberProto = phoneUtil.parse(phone, "");
            //    int countryCode = numberProto.getCountryCode();
            //}
            //catch (NumberParseException e)
            //{
            //    System.err.println("NumberParseException was thrown: " + e.toString());
            //}

        //}
    }
    
}
