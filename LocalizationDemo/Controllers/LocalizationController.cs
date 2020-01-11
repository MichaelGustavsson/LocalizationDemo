using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationDemo.Controllers
{
    public class LocalizationController : Controller
    {
        [HttpPost]
        public IActionResult ChangeLanguage(string uiCulture, string returnUrl)
        {
            IRequestCultureFeature feature =
                HttpContext.Features.Get<IRequestCultureFeature>();

            RequestCulture requestCulture =
                new RequestCulture(feature.RequestCulture.Culture,
                                   new CultureInfo(uiCulture));

            string cookieValue =
                CookieRequestCultureProvider.MakeCookieValue(requestCulture);

            string cookieName =
                CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(cookieName, cookieValue);

            return LocalRedirect(returnUrl);
        }
    }
}