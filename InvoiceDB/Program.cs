using InvoiceDB.Rep;
using PhoneNumbers;
using System.CodeDom.Compiler;

//var telephoneNumber = "37061853881";
//PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
//PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, dialFrom);
//// Produces 0333 6329900  
//var displayNumber = phoneUtil.FormatOutOfCountryCallingNumber(phoneNumber, dialFrom);
//Console.WriteLine(displayNumber);
namespace InvoiceDB
{
    public class Program
    {
       

        public static void Main(string[] args)
        {
           // var guestRep = new GuestRepository();
            var orderRep = new OrderRepository();
           // var taxRep = new TaxRepository();
            //var runGenerator = new RunInvoiceGenerator();
            var name = new List<Order>();

            name.ForEach(Console.WriteLine);

            //runGenerator.GenerateExelRevile(data.Items );
            Console.WriteLine("Saskaitos sugeneruotos");
            Console.ReadKey();

        }
        public string GetInvoiceData()
        {
            Console.WriteLine("Iveskite Saskaitu Data /2022-01-01/");
            return Console.ReadLine();
        }
        public void GetOrder()
        {
            var name = new List<Order>();

            name.ForEach(Console.WriteLine);
           
        }
    }
}
            