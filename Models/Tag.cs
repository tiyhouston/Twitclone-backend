using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class Tag: HasId{
    public int Id{get; set;}
    public string Value{get; set;}
    public DateTime CreatedAt{get; set;}
    int TweetId {get; set;}
}
public partial class DB : DbContext {
    public DbSet<Tag> Tags { get; set; }
}    