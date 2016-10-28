using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class DB : DbContext {

    public DB(): base(){}
    // public DB(IDbContextFactory<DB> factory): base(){}

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        // options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        // Sqlite can also take other connection strings; 
        // Exeternal data sources can also be used:
        // i.e. 
        // @"Data Source=d:\otherdrive.db"
        // @"Data Source=http://...."
        //
        // use sqlite
        //
        // options.UseSqlite("Filename=./app.db");
        //
        // or use in-memory db
        options.UseInMemoryDatabase();
        // 
        // or postgres
        // options.usePostgresSql();
    }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<Blog>().ToTable("Blog"); // rename Blogs table to Blog
            builder.Entity<Post>().ToTable("Post"); // rename Posts table to Post
        }

    // public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
}