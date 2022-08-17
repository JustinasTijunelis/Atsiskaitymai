using InvoiceDB.Entity;
using InvoiceDB.Rep;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; } //Pataisytas, pataisyti lokacija
        public string Property { get; set; }
        public string GuestFirstName { get; set; }  // pataisyti lokacija
        public string GueasLastName { get; set; } //nesuvestas
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public int Nights { get; set; }
        public decimal RentAmount { get; set; }
        public decimal CleaningFee { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string GuestEMail { get; set; } //nesuvestas
        public string CreatedDate { get; set; } //Nesuvestas
        public string GuestPhoneNumber { get; set; } //nesuvestas
        public decimal CityTax { get; set; } 
        public int AdultsAmount { get; set; }
        public string Source { get; set; }
        public string GuestCode { get; set; }
        public decimal CleaningFeeTax { get; set; }
        public string InvoiceData { get; set; }
        public string InvoiceNr { get; set; }

        public List<Guest> Guests { get; set; }
        public List<Tax> Taxs { get; set; }


        public Order() { }

        public Order(string[] rawData)
        {
            OrderId = rawData[21].Trim('"');
            Property = rawData[0].Trim('"');
            GuestFirstName = rawData[19].Trim('"');
            GueasLastName = rawData[20].Trim('"');
            CheckInDate = rawData[4].Trim('"');
            CheckOutDate = rawData[5].Trim('"');
            Nights = Convert.ToInt32(rawData[7]);
            RentAmount = Convert.ToDecimal(GetRentAmountAll(rawData[21].Trim('"'), rawData[2].Trim('"')));
            CleaningFee = Convert.ToDecimal(GetCleaningFeeAll(rawData[21].Trim('"'), rawData[2].Trim('"')));
            TaxAmount = Convert.ToDecimal(GetVatTaxAll(rawData[21], rawData[2]));
            TotalAmount = Convert.ToDecimal(RentAmount + CleaningFee + TaxAmount + CityTax);
            GuestEMail = rawData[16].Trim('"');
            CreatedDate = rawData[17].Trim('"');
            GuestPhoneNumber = rawData[18].Trim('"');
            CityTax = Convert.ToDecimal(GetCityTaxAll(rawData[21], rawData[2]));
            AdultsAmount = Convert.ToInt32(rawData[22].Trim('"'));
            Source = rawData[2];
            GuestCode = "1" + Convert.ToString(RandmNr());
            CleaningFeeTax = Convert.ToDecimal(CleaningFee * Convert.ToDecimal(0.08257));
            InvoiceData = GetInvoiceDataAll();
            InvoiceNr = InvoiceData +"_"+ RandmNr();
        }
        //public Order(
        //    string OrderId, string property, string guestFirstName,
        //    string gueasLastName, string checkInDate,
        //    string checkOutDate,
        //    int nights, decimal rentAmount,
        //    decimal cleaningFee, decimal taxAmount,
        //    decimal totalAmount, string guestEMail,
        //    string createdDate, string guestPhoneNumber, int cityTax, int adultsAmount, string source)
        //{
        //    this.OrderId = OrderId;
        //    Property = property;
        //    GuestFirstName = guestFirstName;
        //    GueasLastName = gueasLastName;
        //    CheckInDate = checkInDate;
        //    CheckOutDate = checkOutDate;
        //    Nights = nights;
        //    RentAmount = rentAmount;
        //    CleaningFee = cleaningFee;
        //    TaxAmount = taxAmount;
        //    TotalAmount = totalAmount;
        //    GuestEMail = guestEMail;
        //    CreatedDate = createdDate;
        //    GuestPhoneNumber = guestPhoneNumber;
        //    CityTax = cityTax;
        //    AdultsAmount = adultsAmount;
        //    Source = source;
        //}

        //public decimal ConvertCulture(string[] rawData)
        //{
        //    // Kaip veikia konverteris Pavyzdys
        //    var culture = CultureInfo.CreateSpecificCulture("es-ES");
        //    decimal decimalEsCulture = Convert.ToDecimal(rawData);
        //    decimalEsCulture.ToString(culture);

        //    return decimalEsCulture;
        //}
        public int RandmNr()
        {
            Random rnd = new Random();
            return rnd.Next(99999);
        }
        public string InvoiveNumber(string[] rawData)
        {

            var invoiceta = InvoiceData;
            var SFDataNr = InvoiceData + "_" + rawData;
            return SFDataNr;

        }
        public string GetInvoiceDataAll()
        {
            var programs = new Program();
            return programs.GetInvoiceData();
        }

        public decimal GetCityTaxAll(string orderId, string name)
        {
            var taxItemRepository = new TaxRepository();
            return taxItemRepository.GetCityTax(orderId, name);
        }
        public decimal GetCleaningFeeAll(string orderId, string name)
        {
            var taxItemRepository = new TaxRepository();
            return taxItemRepository.GetCleaningFee(orderId, name);
        }
        public decimal GetVatTaxAll(string orderId, string name)
        {
            var taxItemRepository = new TaxRepository();
            return taxItemRepository.GetVatTax(orderId, name);
        }
        public decimal GetRentAmountAll(string orderId, string name)
        {
            var taxItemRepository = new TaxRepository();
            return taxItemRepository.GetRentAmount(orderId, name);
        }

    }
}

