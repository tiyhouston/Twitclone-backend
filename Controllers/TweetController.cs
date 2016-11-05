using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

[Route("/api/tweet")]

public class TweetAPIController : CRUDController<Tweet> {
    //private IRepository<Tweet> tweets;
    public TweetAPIController(IRepository<Tweet> t) : base(t){
        //tweets = t;
    }

    [HttpGet("search")]
   public IActionResult Search([FromQuery]string term, int Id = -1){
        return Ok();
    //    return Ok(tweets.Read(dbset => dbset.Where(tweet => 
    //        tweet.Id.IndexOf(term) != -1
    //        || tweet.Content.IndexOf(term) != -1
    //    )));
   }


}


    
    // [HttpPost]
    // public IActionResult Create([FromBody]Tweet t){
    //     T Create(T item);
    //     return Ok();
    // }
