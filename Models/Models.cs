
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

public class Post
{
    // sometimes, people use Guids
    public int PostId { get; set; }
    // [required] - we can require some attributes - throw errors if the model isn't valid
    public string Title { get; set; }
    public string Content { get; set; }
    // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime createdAt { get; set; }
    // public Blog Blog { get; set; }

    /*
    other attributes
    [StringLength(30)]
    [StringLength(60, MinimumLength = 3)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    [Required]
    [Range(1, 100)]
    [DataType(DataType.Currency)] - supplies formatting preferences to the view
    [DisplayForm(ApplyFormatInEditMode = true)] - when editing, also formats it, not best option for currency/numbers
    // the following ae used when rendering a form field in Razor
    [EmailAddress]	type=”email”
    [Url]	type=”url”
    [HiddenInput]	type=”hidden”
    [Phone]	type=”tel”
    [DataType(DataType.Password)]	type=”password”
    [DataType(DataType.Date)]	type=”date”
    [DataType(DataType.Time)]	type=”time”
    */
}

/*
public class User
 {
     [Required(ErrorMessage = "The Email field is required.")]
     [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
     [Display(Name = "Email")]
     public string Email { get; set; }

     [Required(ErrorMessage = "The Password field is required.")]
     [StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
     [DataType(DataType.Password)]
     [Display(Name = "Password")]
     public string Password { get; set; }

     [DataType(DataType.Password)]
     [Display(Name = "Confirm password")]
     [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
     public string ConfirmPassword { get; set; }
 }
 */

// Models can contain other Models...
// public class Blog
// {
//     public int BlogId { get; set; }
//     public string Url { get; set; }
//     public List<Post> Posts { get; set; }
// }

public static class Seed
{
    public static void Initialize(DB db)
    {
        db.Database.EnsureDeleted(); // delete then, ...
        db.Database.EnsureCreated(); // create
        
        // Look for any Posts.
        if (db.Posts.Any())
        {
            return; // DB has been seeded already
        }
        
        List<Post> posts = new List<Post>();
        // Blog mine = new Blog {Url = "mkeas.org"};
        // db.Blogs.Add(mine);
        for(var i = 0; i < 10; i++){
            db.Posts.Add(new Post { Title = $"Test Post {i}", Content = $"Test Content {i}" }); // Date=DateTime.Parse("2005-09-01")}
        }

        // Console.WriteLine(db.Database);
        db.SaveChanges();

        // print out the tables 
        Console.WriteLine("-----------------------");
        // Console.WriteLine(db.Blogs.ToList().Count);
        Console.WriteLine(db.Posts.ToList().Count);
    }
}