using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class Like: HasId{
    public int Id{get; set;}
    public DateTime CreatedAt{get; set;}= DateTime.Now;
    public int TweetId {get; set;}
}
public partial class DB : DbContext {
    public DbSet<Like> Likes { get; set; }
}    