using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class DB : DbContext {

    public DB(DbContextOptions context): base(context){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<TweetList> TweetList { get; set; }
    public DbSet<Tweet> Twitclone { get; set; }
}