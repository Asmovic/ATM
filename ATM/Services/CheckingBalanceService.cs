using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;

namespace ATM.Services
{
    public class CheckingBalanceService
    {
        private ApplicationDbContext db;

        public CheckingBalanceService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateCheckingBalance ( string firstName, string lastName, string userId, decimal initialBalance)
        {
            
            var accountNumber = (1234567 + db.CheckingBalances.Count()).ToString().PadLeft(10, '0');
            var checkingBalance = new CheckingBalance { firstName = firstName, lastName = lastName, AccountNumber = accountNumber, balance = initialBalance, ApplicationUserId = userId };
            db.CheckingBalances.Add(checkingBalance);

            db.SaveChanges();
        }


        public void Create(string acctno, string firstName, string lastName, string userId, decimal initialBalance)
        {

           // var accountNumber = (1234567 + db.CheckingBalances.Count()).ToString().PadLeft(10, '0');
            var checkingBalance = new CheckingBalance { AccountNumber = acctno, firstName = firstName, lastName = lastName, balance = initialBalance, ApplicationUserId = userId };
            db.CheckingBalances.Add(checkingBalance);

            db.SaveChanges();
        }
    }
}