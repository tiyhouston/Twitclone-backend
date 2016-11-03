using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/api/tweet/tag")]

public class TagAPIController : CRUDController<Tag> {
    private IRepository<Tag> tags;
    public TagAPIController(IRepository<Tag> t) : base(t){
        tags = t;
    }
}