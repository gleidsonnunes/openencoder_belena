using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace openencoder.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return RedirectPermanent("/dashboard");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        [HttpGet("/dashboard/login")]
        public IActionResult Login()
        {
            return RedirectPermanent("~/MicrosoftIdentity/Account/SignIn/OpenIdConnect");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/status")]
        public IActionResult Status()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/jobs")]
        public IActionResult Jobs()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/encode")]
        public IActionResult Encode()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/queue")]
        public IActionResult Queue()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/workers")]
        public IActionResult Workers()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/machines")]
        public IActionResult Machines()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/presets")]
        public IActionResult Presets()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/users")]
        public IActionResult Users()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/settings")]
        public IActionResult Settings()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }

        //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(AuthenticationSchemes = TokenDefaults.AuthenticationScheme)]
        [HttpGet("/dashboard/profile")]
        public IActionResult Profile()
        {
            return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
        }
    }
}
