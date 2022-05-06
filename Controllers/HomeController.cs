using Microsoft.AspNetCore.Mvc;

namespace openencoder.Controllers;
public class HomeController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return RedirectPermanent("/dashboard");
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/status")]
    public IActionResult Status()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/jobs")]
    public IActionResult Jobs()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/encode")]
    public IActionResult Encode()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/queue")]
    public IActionResult Queue()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/workers")]
    public IActionResult Workers()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/machines")]
    public IActionResult Machines()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/presets")]
    public IActionResult Presets()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/users")]
    public IActionResult Users()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/settings")]
    public IActionResult Settings()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }

    [HttpGet("/dashboard/profile")]
    public IActionResult Profile()
    {
        return PhysicalFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }
}