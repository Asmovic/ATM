using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json;

namespace ATM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
     
      

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string Pin { get; set; }

      
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

//        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
//{
//    ...
//}


        public DbSet<CheckingBalance> CheckingBalances { get; set; }

        public DbSet<Transactionz> Transactions { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Customers> customer { get; set; }
        public DbSet<Transaction> trans { get; set; }



    }
}