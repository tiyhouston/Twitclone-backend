using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public class Tweet : HasId 
{
    public int Id{get; set;}
    public string Content{get; set;}
    public User User{get; set;}
    public int ReplyToTweet{get; set;}
    public bool IsRetweet{get; set;}
    public List<Tag> Tags{get; set;}
    public int Likes{get; set;}
    public DateTime CreatedAt{get; set;} = DateTime.Now; 
    
}
    

public class Twitclone : HasId {
    public int Id { get; set; }
    public List<Tweet> TweetLists { get; set; }
    public List<User> Users {get; set;}

}


public partial class DB : DbContext {
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<Tweet> Twitclone { get; set; }
    
}

public partial class Handler {
   public void RegisterRepos(IServiceCollection services){
       Repo<Tweet>.Register(services, "Tweets", d => d.Include(b => b.User).Include(t => t.Tags));
       Repo<Twitclone>.Register(services, "Twitclone",
           d => d.Include(b => b.TweetLists).ThenInclude(l => l.Tags));
       Repo<User>.Register(services, "Users");
       Repo<Like>.Register(services, "Likes");
   }
}
