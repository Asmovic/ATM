using ATM.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Services;
using Microsoft.AspNet.Identity.Owin;






namespace ATM.Controllers
{
    [Authorize]
    public class CheckingBalanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
         
        //
        // GET: /CheckingBalance/
        public ActionResult Index()
        {

            var gf = "sccs";
            return View(gf);
        }

        //
        // GET: /CheckingBalance/Details
      //  [Route("/CheckingBalance/Details")]
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            db.Configuration.ProxyCreationEnabled = false;
            CheckingBalance usid = new CheckingBalance();
            usid = db.CheckingBalances.Where(c => c.ApplicationUserId == userId).First();
            return Json(usid, JsonRequestBehavior.AllowGet);

            }

        public ActionResult List()
        {

            return View(db.CheckingBalances.ToList());
        }

        //
        // GET: /CheckingBalance/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CheckingBalance/Create



        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var userId = User.Identity.GetUserId();

            try
            {
                foreach (string _formData in collection)
                {
                    ViewData[_formData] = collection[_formData];
                }

                var service = new CheckingBalanceService(HttpContext.GetOwinContext().Get<ApplicationDbContext>());

                service.CreateCheckingBalance(ViewData["firstName"].ToString(), ViewData["lastName"].ToString(), userId, decimal.Parse(ViewData["balance"].ToString()));
         

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public void CreateCheckingBalance(string firstName, string lastName, string userId, decimal initialBalance)
        {

            var accountNumber = (1234567 + db.CheckingBalances.Count()).ToString().PadLeft(10, '0');
            var checkingBalance = new CheckingBalance { firstName = firstName, lastName = lastName, AccountNumber = accountNumber, balance = initialBalance, ApplicationUserId = userId };
            db.CheckingBalances.Add(checkingBalance);

            db.SaveChanges();
        }


          //[HttpPost]
          //[ValidateAntiForgeryToken]
          //public ActionResult Create([Bind(Include = "id,AccountNumber,firstName,lastName,balance,ApplicationUserId")] CheckingBalance chk)
          //{
          //    if (ModelState.IsValid)
          //    {
          //        db.CheckingBalances.Add(chk);
          //        db.SaveChanges();
          //        return RedirectToAction("Index");
          //    }

          //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", chk.ApplicationUserId);
          //    return View(chk);
          //}

          

        //
        // GET: /CheckingBalance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CheckingBalance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CheckingBalance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CheckingBalance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
