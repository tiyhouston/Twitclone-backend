using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/")]

public class TweetController : Controller {
    private IRepository<Tweet> tweets;
    public TweetController(IRepository<Tweet> t){
        tweets = t;
    }

    
    [HttpGet]
    public IActionResult Index(){
        return Ok();
    }

}    
