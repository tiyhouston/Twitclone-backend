using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/api/tweet/like")]

public class LikeAPIController : CRUDController<Like> {
    private IRepository<Like> likes;
    public LikeAPIController(IRepository<Like> l) : base(l){
        likes = l;
    }
}
