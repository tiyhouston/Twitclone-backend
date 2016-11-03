// using Microsoft.AspNetCore.Mvc;
// using System.Linq;

// [Route("/")]
// public class HomeController : Controller
// {
//     private IRepository<Tweet> tweets;
//     // private IRepository<TweetList> lists;
//     public HomeController(IRepository<Tweet> tweets){
//         this.tweets = tweets;
        
//     }

//     [HttpGet("/{username?}")]
//     [HttpGet("Home/Index/{username?}")]
//     public IActionResult Root(string username = "you")
//     {
//         ViewData["Message"] = "Some extra info can be sent to the view";
//         ViewData["Username"] = username;
//         return View("Index"); // View(new Student) method takes an optional object as a "model", typically called a ViewModel
//     }
// }