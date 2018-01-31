using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();  //instance of the class

        // GET: LuckyNumber
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };
            dbc.LuckyNumbers.Add(myLuck); // getting properties from myLuck (number and balance)
            dbc.SaveChanges(); //saving changes (go out and touch a database)
            return View("Spin", myLuck);
        }

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky) //getting value from the model
        {
            //trying to get balance just from one //COMING FROM DATABASE
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m => m.LuckyNumberID == 1).First(); //return 1 record as a luckyNumber


//change the balance in the database
            if(lucky.Balance>0)
            {
                databaseLuck.Balance -= 1;
            }
            //update the number in the database using the form submission value
            databaseLuck.Number = lucky.Number; //info from database = info from model.. take from model and put into database
            

            dbc.SaveChanges();

            return View(databaseLuck);
        }
    }
}