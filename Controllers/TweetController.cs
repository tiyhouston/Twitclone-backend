using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/api/tweet")]

public class TweetAPIController : CRUDController<Tweet> {
    private IRepository<Tweet> tweets;
    public TweetAPIController(IRepository<Tweet> t) : base(t){
        tweets = t;
    }
}
    
    // [HttpPost]
    // public IActionResult Create([FromBody]Tweet t){
    //     T Create(T item);
    //     return Ok();
    // }
