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
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        // GET: LuckyNumber
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };
            return View(myLuck);
        }

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
            if(lucky.Balance>0)
            {
                lucky.Balance -= 1;
            }


            return View(lucky);
        }
    }
}