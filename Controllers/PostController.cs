using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

/*

A route can return a view, or a status message with data

return View(new { Username = "you" });
return Ok("ok.");
return Ok(new { some="data", can="be sent here" });

A route can talk to the db and return JSON

// Querying
var blogs = db.Blogs
    .Where(b => b.Rating > 3)
    .OrderBy(b => b.Url)
    .ToList();

return Ok(blogs);

A route can take arguments and save to the db

// Saving
var blog = new Blog { Url = "http://sample.com" };
db.Blogs.Add(blog);
db.SaveChanges();

Amongst these actions, a route can create new model instances, and save them to
the db or it can pass them along to a View:

return View(new Greeting { Username = "you" });

Routes can be written to handle URI options:

[Route("/posts")]
[Route("/posts/{id}")]
[Route("/posts/{id}/{username?}")]

These are passed into the method as named arguments:

public IActionResult GetPosts(string id, string? username){...}

GET params are passed as arguments to the Route method

[Route("/posts")]
public IActionResult Get(string filter = "tutorials"){
    // if ?filter=videos is in the URL, filter above becomes "videos"
}

Each Route will respond to all HTTP Verbs unless you explicitly use a particular attribute for the verb you want:

[HttpPost] / [HttpPost("sub/route/{id}")]
[HttpGet] / [HttpGet("sub/route/{id}")]
[HttpPut] / [HttpPut("sub/route/other/route")]
[HttpDelete] / etc

Usually, instead of supplying a Route and HTTP Verb attribute, we supply the route to the HTTP Verb Attribute:

[HttpGet("sub/route/{id}")]

A Controller can define a root route, too! Then your route methods can define the subroute:

[Route("/mycontroller")]
class MyController : Controller {
    [HttpGet("{id?}")]
    public IActionResult Get(int? id){
        // if id provided, return that single instance
        if(id.HasValue)
            return Ok(db.Posts.FIrstOrDefault(e => e.Id === id.Value));
        // else return all items in the collection
        return Ok(db.Posts);
    }
}

Post/Put routes can also have an attribute ([FromBody]) to parse form body-data into a model instance:

[HttpPost]
public IActionResult Post([FromBody]Post p){
    db.Posts.Add(p);
    db.SaveChanges();
    return Created("Get", p);
}

Each Route that handles Post/Put data may also need some extra security measures:

[ValidateAntiForgeryToken]

Route methods can be async:

public async Task<IActionResult> GetPosts(...){
    var posts = await GetPostsFromDB();
}

There are also other properties and methods available inside Route methods:
ViewData - Dictionary<string, string> that is accessible inside View()s
ModelState - contains the model instance being passed into the route (auto-parsed by MVC),
    has properties like ModelState.IsValid
RedirectToLocal(url) - redirect a client to a different url on the server
AddErrors(...) - build up errors to send

-----------

RESTful takes these endpoints for each resource

API	                    Description	            Request body	        Response body
--------------------------------------------------------------------------------------------
GET /api/todo	        Get all to-do items	    None	                Array of to-do items
GET /api/todo/{id}	    Get an item by ID	    None	                To-do item
POST /api/todo	        Add a new item	        To-do item	            To-do item
PUT /api/todo/{id}	    Update an existing item	To-do item (full)       None
PATCH /api/todo/{id}	Update an existing item	To-do item (partial)	None
DELETE /api/todo/{id}	Delete an item.	        None	                None

*/

[Route("/api/[controller]")] // grabs "Post" from the controller name
// can also just do [Route("/api/posts")]
// additionally, can have /api/[controller]/[action]
public class PostController : Controller
{
    private DB db;

    public PostController(DB db){
        this.db = db;
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(db.Posts.OrderBy(p => p.Title).ToList());

    [HttpGet("{id}", Name = "GetPost")] // can include an optional name for the route
    public IActionResult Get(int id) {
        Post item = db.Posts.First(p => p.PostId == id);
        if(item == null){
            return NotFound();
        }
        return Ok(item); 
    }

    [HttpGet("sql/{id}")]
    public IActionResult SQL(int id) {
        return Ok(db.Posts.FromSql($"select * from dbo.Post where PostId = {id}").ToList()); // only works with SQL, not in-memory
    }

    [HttpPost]
    public IActionResult Post([FromBody]Post p){
        if(p == null){
            return BadRequest();
        }
        db.Posts.Add(p);
        db.SaveChanges();
        return Ok(p);
        // optionally, be more formal, and point to the get/{id} with a 201 code
        // tells a client where t grab the most recent data, and sends 'p' along with the 
        // body of the response
        // return CreatedAtRoute("GetPost", new { id = p.PostId}, p);
    }

    /**
    Other attributes for Model Binding
    [BindRequired]: This attribute adds a model state error if binding cannot occur.
    [BindNever]: Tells the model binder to never bind to this parameter.
    [FromHeader], [FromQuery], [FromRoute], [FromForm]: Use these to specify the exact binding source you want to apply.
    [FromServices]: This attribute uses dependency injection to bind parameters from services.
    [FromBody]: Use the configured formatters to bind data from the request body. The formatter is selected based on content type of the request.
    [ModelBinder]: Used to override the default model binder, binding source and name.
    */

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Post newPost){
        if(newPost == null || newPost.PostId != id)
            return BadRequest();
        var post = db.Posts.First(p => p.PostId == id);
        if(post == null)
            return NotFound();
        db.Posts.Remove(post);
        db.Posts.Add(newPost);
        db.SaveChanges();
        return new NoContentResult(); // sends back a 204 Ok. (no content to be sent back to client)
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var p = db.Posts.First(x => x.PostId == id);
        if (p == null)
            return NotFound();
        db.Posts.Remove(p);
        return new NoContentResult(); // sends back a 204 Ok. (no content to be sent back to client)
    }

    /**
    Types of responses (these methods create an IActionResult):

    View - Returns a view that uses a model to render HTML. Example: return View(customer);
    
    HTTP Status Code - Return an HTTP status code. Example: return BadRequest();

    Formatted Response - Return Json or similar to format an object in a specific manner. 
        
        Example: return Json(customer);

    Content negotiated response - Instead of returning an object directly, an action can return a content negotiated response (using Ok, BadRequest, NotFound, File, Forbid, Unauthorized, LocalRedirect, Redirect, NoContent, RedirectPermanent, RedirectToAction, RedirectToActionPermanent, RedirectToRoute, Created, CreatedAtRoute or CreatedAtAction, or just plain ol' StatusCode). 
    
        Examples: return Ok(); or return CreatedAtRoute("routename", values, newobject);

    Redirect - Returns a redirect to another action or destination (using Redirect, LocalRedirect, RedirectToAction or RedirectToRoute). 
    
        Example: return RedirectToAction("Complete", new {id = 123});

    **/
}