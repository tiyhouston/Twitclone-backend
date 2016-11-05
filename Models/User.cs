using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public class User: HasId{
    public int Id{get; set;}
    public string Username{get; set;}
    public string AvatarURL{get; set;}
    public DateTime CreatedAt{get; set;}
    public int TweetId {get; set;}

} 

public partial class DB : DbContext {
    public DbSet<User> Users { get; set; }
}    

// public partial class Handler {
//    public void RegisterRepos(IServiceCollection services){
      

//    }

// }



  