using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebApp1.App_Start.StartupAuth))]

namespace WebApp1.App_Start
{
	public class StartupAuth
	{

        public void Configuration(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user   
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider   
            // Configure the sign in cookie   
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/SignOut"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30.0)
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Uncomment the following lines to enable logging in with third party login providers   
            //app.UseMicrosoftAccountAuthentication(   
            // clientId: "",   
            // clientSecret: "");   
            //app.UseTwitterAuthentication(   
            // consumerKey: "",   
            // consumerSecret: "");   
            //app.UseFacebookAuthentication(   
            // appId: "",   
            // appSecret: "");   
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()   
            //{   
            // ClientId = "",   
            // ClientSecret = ""   
            //});   
        }
    }
}
