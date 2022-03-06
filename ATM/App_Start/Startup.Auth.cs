using ATM.Controllers;
using ATM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Newtonsoft.Json;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;


namespace ATM
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
          //  app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager);


            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                //Provider = new CookieAuthenticationProvider
                //{
                //    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager,ApplicationUser>(
                //    validateInterval: TimeSpan.FromMinutes(30),
                //    regenerateIdentity:(manager,user) =>
                //    user.GenerateUserIdentityAsync(manager))
                //}
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            app.UseFacebookAuthentication(
               appId: "802933260050030",
               appSecret: "b7c3d4f1321996d712548b67095ed69b");

            //app.UseGoogleAuthentication(
            //        clientId: "508582802089-ip3sfd7a2emfd1lvp7n177lg46kj4m1q.apps.googleusercontent.com",
            //        clientSecret: "AIzaSyDvsSeOg6RSL2lF2Hybr6Sm2R60GDTxDM4");
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    clientId: "508582802089-ip3sfd7a2emfd1lvp7n177lg46kj4m1q.apps.googleusercontent.com",
            //    clientSecret: "AIzaSyDvsSeOg6RSL2lF2Hybr6Sm2R60GDTxDM4",
            //    Provider = new GoogleOAuth2AuthenticationProvider()
            //});

                
        }
    }
}