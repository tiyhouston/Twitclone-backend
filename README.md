# .NET Core Boilerplate

> note: alpha stages

# How to use

1. Optional: fork to your own account on GitHub
2. clone to your machine
3. `dotnet restore`
4. modify Models/*.cs to create your csharp Models for Entity Framework Core; add any seeded data to the `Seeder` class
5. `dotnet ef migrations add init` - create the initial migrations for the database seeding
6. `dotnet ef database update` - write the migrations to the database
7. `dotnet watch run` - run and watch the file changes;
8. if at any point you install a package through NuGet or change the project.json file - stop the watcher and re-run step 3 and step 7
9. if at any point you change a model, rerun steps 5 and 6
10. open `http://localhost:5000` to view local server
11. to deploy:

    To https://now.sh:
    - `npm install -g now`
    - from project folder: `now`
    - open the url provided

    To https://heroku.com
    - install the heroku CLI (https://devcenter.heroku.com/articles/heroku-command-line)
    - (update and commit all your local git files)
    - `heroku create --buildpack http://github.com/noliar/dotnet-buildpack.git`
    - `git push heroku master`
    - `heroku open`

# Support

1. Please submit issues on GitHub with proper taggings / labels.
2. Reach out to [@matthiasak](https://twitter.com/matthiasak).