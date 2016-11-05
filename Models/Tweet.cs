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
    public Tweet ReplyTo{get; set;}
    public bool IsRetweet{get; set;}
    public List<Tag> Tags{get; set;}
    public List<Like> Likes{get; set;}
    public List<Tweet> Retweets{get; set;}
    public DateTime CreatedAt{get; set;}
    public int ReplyToTweet{get; set;}
}
    //private List<Tweet> tweets = new List<Tweet>();

public class Twitclone : HasId {
    public int Id { get; set; }
    public List<Tweet> TweetLists { get; set; }
    public List<User> Users {get; set;}

}

// public class TweetList : HasId {
//     public int Id {get; set;}
//     public List<Tweet> Tweets { get; set}

// }
public partial class DB : DbContext {
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<Tweet> Twitclone { get; set; }
    
}

public partial class Handler {
   public void RegisterRepos(IServiceCollection services){
       Repo<Tweet>.Register(services, "Tweets");
    //    Repo<TweetList>.Register(services, "TweetLists",
    //        d => d.Include(l => l.Cards));
       Repo<Twitclone>.Register(services, "Twitclone",
           d => d.Include(b => b.Lists).ThenInclude(l => l.Tweets));
        Repo<User>.Register(services, "Users");
   }
}
