using System;
using System.Collections.Generic;
using System.Linq;

public static class Seed
{
    public static void InitializeDev(DB db)
    {   
        // Look for any Tweets.
        if (db.Tweets.Any() || db.TweetList.Any())
        db.Database.EnsureDeleted(); // delete then, ...
        db.Database.EnsureCreated(); // create the tables!! 
        
        TweetList todo = new TweetList { Summary="Tweets", Tweets = new List<Tweet>() };

        for(var i = 0; i < 10; i++){
            todo.Tweets.Add(
                new Tweet { Content = $"Tweet Content {i}",  }
            );
        }

         db.TweetList.Add(todo);

        db.SaveChanges();

        // print out the tables 
        Console.WriteLine("----------TWEETS SEEDED-------------");
    }

    // public static void InitializeProd(DB db){
    //     db.Database.EnsureCreated();
    //      db.Database.Migrate();
    // }
}