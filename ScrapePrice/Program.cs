using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using ExpediaDownload.Module;
using ExpediaDownload.Module.BusinessObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ScrapePrice
{
    class Program
    {
        static void Main(string[] args)
        {

            //https://www.expedia.ca/all-inclusive-vacation/search?origin=YYZ&departure=16%2F06%2F2019&adultCount=2&starRating=0-&price=0-&start=1&roomCount=1&destination=1341400&duration=7&sort=RELEVANCE&supplierHotelId=10356


            DateTime Startdate = DateTime.Now;

            while (Startdate < Startdate.AddDays(100))
            {

                Startdate =  Startdate.AddDays(1);

                try
                {

              
                //get search month
                string searchmonth = Startdate.Month.ToString();
                string seatchday = Startdate.Day.ToString();
                if (seatchday.Length != 2)
                {
                    seatchday = "0" + seatchday;
                }
                if (searchmonth.Length != 2)
                {
                    searchmonth = "0" + searchmonth;
                }

                //download the string

                string searchurl = @"https://www.expedia.ca/all-inclusive-vacation/search?origin=YYZ&departure=" + seatchday + @"%2F" + searchmonth + "%2F2019&adultCount=2&starRating=0-&price=0-&start=1&roomCount=1&destination=1341400&duration=7&sort=RELEVANCE&supplierHotelId=10356";

                string url2 = @"https://www.expedia.ca/all-inclusive-vacation/search?origin=YYZ&departure=17%2F06%2F2019&adultCount=2&starRating=0-&price=0-&start=1&roomCount=1&destination=1341400&duration=7&sort=RELEVANCE&supplierHotelId=10356";
                var returstring = DownloadString(searchurl);

         
   

                var numberfound = returstring.Replace("C", "").Replace(",","").Replace("$", "");

           

                ServerHelper mysession = new ServerHelper();

                using (UnitOfWork uow = new UnitOfWork(mysession.CurrentSession.DataLayer))
                {

                    Resort  luxry = uow.FindObject<Resort>(new BinaryOperator("Name", "luxry"));

                    Listing newlisting = new Listing(uow);

                    newlisting.Price = Convert.ToDecimal(numberfound);
                    newlisting.Resort = luxry;
                    newlisting.ListingDate = Startdate;

                    uow.CommitChanges();

                    Console.WriteLine(Startdate.ToShortDateString() + " : " + numberfound);

                  
                }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                Thread.Sleep(500);

            }
        }

        public static string DownloadString(string address)
        {
            string sourcecode = "";

            //init diever
            using (ChromeDriver driver = new ChromeDriver())
            {
                //set the url
                string payloadurl = address;
                driver.Navigate().GoToUrl(payloadurl);
                //set up wait timer
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(120));

                //userDetails

                wait.Until(drivermy =>
               driver.FindElement(By.ClassName("userDetails"))

                   );

                //dl string

                var src = driver.FindElementsByClassName("price");

                 sourcecode = src[1].GetAttribute("innerHTML");

                driver.Close();
            }
            return sourcecode;
        }
    }
}
