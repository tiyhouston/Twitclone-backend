using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
