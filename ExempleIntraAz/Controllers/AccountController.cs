using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace ExempleIntraAz.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguration _conf;
        public AccountController( IConfiguration conf)
        {

            _conf = conf;
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            /*Workaround avec redirection vers l'url explicaite de déconnexion de Azure*/
            await HttpContext.SignOutAsync(new AuthenticationProperties
            {
                RedirectUri = _conf["AzureAd:PostLogoutRedirectUri"]
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);



            return RedirectToAction("Login");
        }
        public IActionResult LoginWithMicrosoft()
        {
            string? redirectUrl = Url.Action("Index", "Secure");

            AuthenticationProperties prop =
                new AuthenticationProperties()
                {
                    RedirectUri = redirectUrl,
                };

            return Challenge(prop, OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
