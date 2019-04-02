This readme will help you get your generated project running on your machine. If you have any questions please 
see https://www.codenesium.com/documentation for the documentation or feel free to email support@codenesium.com.


# Running the API project
To run the API project you should set the <Project_Name>.Api.Web project to be the default startup project.

If you're working with an existing database you most likely do not want to migrate your database so MigrateDatabase should be set to false
in your appSettings.Development.json. If you do not already have a database, set this variable to true and when the app
starts it will migrate your database to use the schema you used to generate.

If ApplicationDbContext in the appSettings file isn't already set you will need to provide a connection string.

You should be able to run the project now and the console should say that it's listening on port 8000 and 
a Swagger window should open in the web browser. You can set the bearer token in Swagger using what's in the Codenesium client
and you should be able to hit your API methods.


# Running the React App
Using VS Code open the <Project_Name>.Api.TypeScript\src\react folder and run "npm install" from a terminal.
This will install all of the node packages you need to run the React app. This assumes you have node
installed. If you do not you will need to install it from https://nodejs.org/en/download. If you don't have 
VS Code you can get it from https://code.visualstudio.com/download.

Although technically you can build Typescript in Visual Studio it is much easier to use VS Code and I encourage you to do so.

After the node packages install you can run "npm run start-win" to run the app and have it configured to point
to the API project. By default the API will be running at localhost:8000 and the React app will run at localhost:3000.
There are lots of different configurations in the package.json file that you can run. For example start-win-playground
will run the React app on your machine but pointed to the Codenesium playground server. 

# Suggested next steps
I recommend throwing away the migrations that come with the project in the <Project_Name>.Api.DataAccess/Migrations/00000000000000_InitialCreate.cs
file and using the built in EF migration tooling. This provided migration is really just to get things up and running. Migrations
are better if you use the EF tooling. https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations

There is docker support. If you have docker installed run DockerWithSQLServer.bat from the solution root to build the app and API
and have it all run together in docker.

The  <Project_Name>.Api.Web can host the API and the React project at the same time. There is code in the Web project startup to
use static file hosting for anything that's in the folder named app in the same folder and the API build. I don't provide an automatic
way to build the react app and have it deployed with the .NET API because I think most people won't host it that way but it does work.

Just run "npm run build-win" and copy the contents of the build direcctory to a directory called app in the .NET API build folder and
when you run the API project it will also serve the react app. You will need to adjust the variables in the package.json to make it
all point where it needs to. 


# Securing app for production
By default we don't provide an email service implementation. There are so many ways to do that I'm just leaving it up to you.
To allow use of the app without having an email provider there is a setting in the appSettings.json called DebugSendAuthEmailsToClient. 
Having this setting enabled will cause Auth emails for registration or changing the account email to be sent directly to the client app. This 
is not secure. Don't run this in production. Provide an email sending implementation and disable this setting so your Auth system is secure.
See https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-2.2&tabs=visual-studio for an example.

You must update the JWT settings in the appSettings file. You need to change the audience and issuer to match your site and provide a long SigningKey which
is the password used to sign the bearer tokens. 

You must set the ExternalBaseUrl variable in app settings to match where the client application is hosted from. This is 
used to tell Auth emails where to go and it needs to match where your site is hosted.