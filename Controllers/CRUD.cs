using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

/*

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
[Route("/api/tweet")]
public abstract class CRUDController<T> : Controller where T: class, HasId
{
    private IRepository<T> r;
    public CRUDController(IRepository<T> r){
        this.r = r;
    }

    [HttpPost]
    public IActionResult C([FromBody] T item) {
        // Console.WriteLine(ModelState);
        // if(!ModelState.IsValid)
        //     return BadRequest(ModelState.to());

            return Ok(r.Create(item));

    }

    [HttpGet("{id?}")]
    public IActionResult R(int id = -1) {
        if(id == -1)
            return Ok(r.Read());
        
        var item = r.Read(id);
        if(item == null)
            return NotFound();
        
        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult U(int id, [FromBody] T item){
        if(item.Id != id || !r.Update(item))
            return BadRequest();

        return Ok(); 
    }

    [HttpDelete("{id}")]
    public IActionResult D(int id){
        T item = r.Delete(id);
        if(item == null)
            return NotFound();
        
        return Ok(item);
    }

    [HttpPost("{id?}/tag")]

    public IActionResult Ctag([FromBody] T item) {
        // Console.WriteLine(ModelState);
        // if(!ModelState.IsValid)
        //     return BadRequest(ModelState.to());

            return Ok(r.Create(item));

    }
}