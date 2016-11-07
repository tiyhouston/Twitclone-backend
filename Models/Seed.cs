using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public static class Seed
{
    public static void Initialize(DB db, bool isDevEnvironment)
    {
        // if(isDevEnvironment){
        //     db.Database.EnsureDeleted(); // delete then, ...
        // }

        // db.Database.EnsureCreated(); // create the tables!!
        // db.Database.Migrate(); // ensure migrations are registered

        if(db.Tweets.Any() || db.Users.Any() || db.Tags.Any() || db.Likes.Any()) return;

        var Users = new List<User> {
            new User {
                Username = "ironicdolphin",
                AvatarURL = "https://images.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.pbs.org%2Fnewshour%2Fwp-content%2Fuploads%2F2014%2F03%2Fdolphin.jpg&f=1"
            },
            new User {
                Username = "TheIronYard",
                AvatarURL = "https://www.theironyard.com/assets/iron-yard-logo-709fbbf7ff0d1d76e83b9a782b79e7c4edb840974a7b3d9dd4f33b8cf5b87571.svg"
            },
            new User {
                Username = "AmazingBeards",
                AvatarURL = "https://images.duckduckgo.com/iu/?u=http%3A%2F%2F4.bp.blogspot.com%2F_lrKSQHqv38Q%2FTQ4kAGAgq4I%2FAAAAAAAAADk%2FkIHFYQ8qVi8%2Fs1600%2Fcool%2Bmustache%2Bgallery.jpg&f=1"
            }
        };

        var Tags = new List<Tag> {
            new Tag { Value = "tacos" },
            new Tag { Value = "bbq" }
        };

        var f = new Tweet {
            Content = "Give me tacos. All. The. Tacos.",
            User = Users[0],
            IsRetweet = false,
            Tags = new List<Tag> { Tags[0] },
            Likes = 1
        };

        db.Tweets.Add(f);
        db.SaveChanges();

        var g = new Tweet {
            Content = "This.",
            User = Users[0],
            ReplyToTweet = f.Id,
            IsRetweet = true,
            Tags = new List<Tag> { Tags[0] },
            Likes = 2
        };

        var Tweets = new List<Tweet> {
            g,
            new Tweet {
                Content = "YOU CAN'T HANDLE THE TACOS",
                User = Users[2],
                ReplyToTweet = f.Id,
                IsRetweet = false,
                Tags = new List<Tag> { Tags[1] },
                Likes = 0
            }
        };

        foreach(var t in Tweets)
            db.Tweets.Add(t);

        db.SaveChanges();
        Console.WriteLine("----------DB SEEDED-------------");
    }
}