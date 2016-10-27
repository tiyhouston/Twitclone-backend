using Microsoft.AspNetCore.Mvc;

[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Root(){
        return Ok("Ok.");
    }

    [HttpGet("Home/Index/{username?}")]
    public IActionResult Index(string username = "you")
    {
        ViewData["Message"] = "Some extra info can be sent to the view";
        ViewData["Username"] = username;
        return View(); // View method takes an object as a "model", typicall called a ViewModel
    }

    [HttpGet("/Errors/{errCode}")]
    public IActionResult Errors(string errCode)
    {
        return (errCode == "500" | errCode == "404")
            ? View($"~/Views/Home/Error/{errCode}.cshtml")
            : View("~/Views/Shared/Error.cshtml");
    }
}