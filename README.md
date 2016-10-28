# .NET Core Boilerplate

> note: alpha stages

# How to use

1. optional: fork to your own account on GitHub
-  clone to your machine
- `npm install -g now yarn`
- `yarn`
- `dotnet restore`
- if using Entity Framework:

    - modify Models/*.cs to create your csharp Models for Entity Framework Core; add any seeded data to the `Seeder` class
    - `dotnet ef migrations add init` - create the initial migrations for the database seeding
    - `dotnet ef database update` - write the migrations to the database
    - if at any point you change a model, rerun these steps above

- `npm start` - runs and watch the files for changes. Underneath, this runs `dotnet watch run` and `npm watch`.
- if at any point you install a package through NuGet or change the project.json file - hit Ctrl+C and run step 3 again.
- open `http://localhost:5000` to view local server

# To deploy

To https://now.sh:

- from project folder: `now --docker`
- open the url provided (`dotnetcore-boilerplate-XXXXXXXXXXXX.now.sh`); when the installation is done the browser will be redirected to your new server
- to setup a custom URL: `now alias dotnetcore-boilerplate-XXXXXXXXXXXX.now.sh YOURAPPNAME.now.sh`

To https://heroku.com

- install the heroku CLI (https://devcenter.heroku.com/articles/heroku-command-line)
- (update and commit all your local git files)
- `heroku create --buildpack http://github.com/noliar/dotnet-buildpack.git`
- `git push heroku master`
- `heroku open`

# Support

1. Please submit issues on GitHub with proper taggings / labels.
2. Reach out to [@matthiasak](https://twitter.com/matthiasak).