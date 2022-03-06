using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ATM.Models;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace ATM.Controllers
{
    
    public class HomeController : Controller
    {
        public static int glb;
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
           
            var userId = User.Identity.GetUserId();

             if(userId != null)
             {
                 var checkingBalanceId = db.CheckingBalances.Where(c => c.ApplicationUserId == userId).First().id;
                 glb = checkingBalanceId;
                 ViewBag.CheckingBalanceId = checkingBalanceId;

                 //  var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
                 var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                 //  var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //     var user = manager.FindById(userId);


              //   ViewBag.Pin = user.Pin;
             }
            
            
            return View();
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}