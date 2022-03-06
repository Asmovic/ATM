using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
       //  GET: /Transaction/Deposit
        //public ActionResult Deposit()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    // db.Dispose();
        //    var dep = db.Transactions.Include(c => c.User);

        //    //  return Json(customers.ToList(), JsonRequestBehavior.AllowGet);
        //    return View(dep.ToList());

        //    //return View();
        //}


        public ActionResult Deposit(int? id)
        {
            id = HomeController.glb;
            db.Configuration.ProxyCreationEnabled = false;
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var cm = db.Transactions.Find(id);

       //    Transactionz dep = cm;
            if (cm == null)
            {
                return HttpNotFound();
            }
        //    return View(cm);

            return Json(cm,JsonRequestBehavior.AllowGet);
        }






         //GET: /Transaction/Deposit/id
      //  [ActionName("PARA")]
        //public ActionResult Deposit(int Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transactionz dep = db.Transactions.Find(Id);
        //    if (dep == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dep);


        //    //var dep =  db.Transactions.Find(CheckingBalanceId);

        //    //   db.PersonalDetails.ToList()
        //    //  db.Transactions.Find(CheckingBalanceId);
        //    // db.Configuration.ProxyCreationEnabled = false;
        //    //return Json(db.Transactions.ToList(), JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult Deposit(Transactionz transaction)
        {
            if(ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
	}
}