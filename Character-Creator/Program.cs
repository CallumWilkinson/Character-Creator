using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using System.Data;
using Character_Creator.Services;

namespace Character_Creator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //create a connection to the database, i should refactor this later to get the file path from appsettings.json instead so it is cleaner
            //the database variable is used to ESTABLISH A CONNECTION to the database, it doesnt CREATE the database
            //should i make this a public field in the program class, above this function so that i can pass it through the dataservice constructor as DataService(database) anywhere in the project?
            IDbConnection dataBaseString = new SqliteConnection("Data Source=C:\\Users\\callu\\Documents\\GitHub\\Character-Creator\\Character-Creator\\Database\\Character-Creator-database.db");


            //create a container
            var builder = WebApplication.CreateBuilder(args);

            //add razorpages and runtime compliation so i can auto reload page while testing
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            //add database object to container
            DataService mainDataBase = new DataService(dataBaseString);
            builder.Services.AddSingleton(mainDataBase);

            //create database table and add initial data to it
            TestSetup setupDatabaseData = new TestSetup();
            setupDatabaseData.Run(dataBaseString);

            //build container
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
