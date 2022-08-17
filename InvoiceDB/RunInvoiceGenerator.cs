using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using InvoiceDB.Rep;
using PdfSharp;
using PdfSharp.Pdf;

namespace InvoiceGenerator
{
    public class RunInvoiceGenerator
    {
       

        //public void GenerateExelInvoice(List<Item> rawData)
        //{
        //    PdfDocument pdfDocument = new PdfDocument();

        //    var item = new List<Item>(rawData);
            


        //    for (int i = 0; i < item.Count; i++)
        //    {
        //        var taxItemRepository = new TaxRepository();
        //        var itemRepository = new OrderRepository();

        //        int num = i;
        //        var SFDataNr = rawData[i].InvoiceData + "_" + num++;
        //        rawData[i].InvoiceNr = SFDataNr;

        //        using var dfDocument = new PdfDocument();

        //        PdfPage pdfPage = dfDocument.AddPage();

        //        using var wbook = new XLWorkbook(@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\InvoiceTheme.xlsx");
        //        var ws1 = wbook.Worksheet(1);
        //        ws1.Cell("D11").Value = rawData[i].GuestName;
        //        ws1.Cell("D12").Value = rawData[i].GueasLastName;
        //        ws1.Cell("D17").Value = rawData[i].GuestEMail;
        //        ws1.Cell("D18").Value = rawData[i].GuestPhoneNumber; 
        //        ws1.Cell("B21").Value = rawData[i].Nights;
        //        ws1.Cell("C21").Value = rawData[i].Property;
        //        ws1.Cell("D21").Value = rawData[i].CheckInDate;
        //        ws1.Cell("E21").Value = rawData[i].CheckOutDate;
        //        ws1.Cell("E24").Value = rawData[i].RentAmount;
        //        ws1.Cell("E26").Value = rawData[i].TaxAmount;
        //        //ws1.Cell("E27").Value = taxItemRepository.GetRentAmount(rawData[i].IdOrder, rawData[i].Source);
        //        ws1.Cell("E25").Value = rawData[i].CleaningFee;
        //        //ws1.Cell("E29").Value = rawData[i].TotalAmount;
        //        ws1.Cell("E8").Value = rawData[i].IdOrder;
        //        ws1.Cell("E5").Value = rawData[i].InvoiceNr;
        //        ws1.Cell("E6").Value = rawData[i].InvoiceData;
        //        ws1.Cell("D15").Value = rawData[i].GuestCode;
        //        ws1.Cell("E28").Value = taxItemRepository.GetCityTax(rawData[i].IdOrder, rawData[i].Source);
                

        //        wbook.SaveAs($@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\AIR{rawData[i].InvoiceData}_{rawData[i].IdOrder}.xlsx");
        //        //dfDocument.Save($@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\AIR{saskaitosData}_{num++}.pdf");
        //    }
        //}
        
        //public void GenerateExelRevile(List<Item> rawData)
        //{
        //    string SFData = Console.ReadLine();
        //    var item = new List<Item>(rawData);
        //    using var wbook = new XLWorkbook(@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\Revile.xlsx");
        //    var ws1 = wbook.Worksheet(1);

        //    for (int i = 0; i < item.Count; i++)
        //    {
        //         var taxItemRepository = new TaxItemRepository();
        //        int num = i;
        //        int exelIndex = i++;
        //        ws1.Cell("A" + exelIndex).Value = SFData;
        //        ws1.Cell("B" + exelIndex).Value = SFData + "_" + num++;
        //        ws1.Cell("C" + exelIndex).Value = rawData[i].GuestCode;
        //        ws1.Cell("D" + exelIndex).Value = rawData[i].GuestName + " " + rawData[i].GueasLastName;
        //        ws1.Cell("E" + exelIndex).Value = "Apgyvendinimo paslaugos";
        //        ws1.Cell("F" + exelIndex).Value = rawData[i].RentAmount;
        //        ws1.Cell("G" + exelIndex).Value = rawData[i].TaxAmount - rawData[i].CleaningFeeTax;
        //        ws1.Cell("H" + exelIndex).Value = rawData[i].TaxAmount+ rawData[i].RentAmount - rawData[i].CleaningFeeTax;
        //        ws1.Cell("I" + exelIndex).Value = Convert.ToDouble(9.000000);
        //        ws1.Cell("J" + exelIndex).Value = "PVM2";

        //        ws1.Cell("A" + exelIndex++).Value = SFData;
        //        ws1.Cell("B" + exelIndex++).Value = SFData + "_" + num++;
        //        ws1.Cell("C" + exelIndex++).Value = rawData[i].GuestCode;
        //        ws1.Cell("D" + exelIndex++).Value = rawData[i].GuestName + " " + rawData[i].GueasLastName;
        //        ws1.Cell("E" + exelIndex++).Value = "Valymas";
        //        ws1.Cell("F" + exelIndex++).Value = rawData[i].CleaningFee;
        //        ws1.Cell("G" + exelIndex++).Value = rawData[i].CleaningFeeTax;
        //        ws1.Cell("H" + exelIndex++).Value = rawData[i].CleaningFee + rawData[i].CleaningFeeTax;
        //        ws1.Cell("I" + exelIndex++).Value = Convert.ToDouble(9.000000);
        //        ws1.Cell("J" + exelIndex++).Value = "PVM2";

        //        ws1.Cell("A" + exelIndex + 2).Value = SFData;
        //        ws1.Cell("B" + exelIndex + 2).Value = SFData + "_" + num++;
        //        ws1.Cell("C" + exelIndex + 2).Value = rawData[i].GuestCode;
        //        ws1.Cell("D" + exelIndex + 2).Value = rawData[i].GuestName + " " + rawData[i].GueasLastName;
        //        ws1.Cell("E" + exelIndex + 2).Value = "Pagalvės mokestis";
        //        ws1.Cell("F" + exelIndex + 2).Value = rawData[i].CityTax;
        //        ws1.Cell("G" + exelIndex + 2).Value = Convert.ToDecimal(0.00);
        //        ws1.Cell("H" + exelIndex + 2).Value = rawData[i].CityTax;
        //        ws1.Cell("I" + exelIndex + 2).Value = Convert.ToDouble(0.000000);
        //        ws1.Cell("J" + exelIndex + 2).Value = "PVM5";
        //    }
        //    wbook.SaveAs($@"C:\Users\User\Desktop\VStudio\InvoiceGenerator\Revile{SFData}.xlsx");
        //}
        
        //public decimal GetCityTax(string OrderId)
        //{
        //    //var item = new List<Item>(rawData);
        //    //var tax = new List<TaxItem>(rawDataTax);
        //    //var income = rawDataTax.OrderBy(d => d.OrderId == g=> g.IdOrder)
        //    //if (rawData.Where(d=> d.IdOrder== g=> g.) == rawDataTax[0].OrderId == rawDataTax[0].FeesName.Contains("City"))
        //    //{
        //    //    decimal cityTax = rawDataTax[0].FeesAmount;
        //    //    return cityTax;
        //    //}
        //}
    } 
}
