namespace ExpensesAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExpensesAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpensesAPI.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //In this method, we can add dummy data (test data) to have in our database
        //for when we will run application.
        protected override void Seed(ExpensesAPI.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Test data that we want to insert into the database. You can write the command
            //Update-Database -v in the package manager console and then check the database
            //to see that the entry is there now (you might have to refresh the db by right clicking
            //on it and click refresh). Without the -v flag, you will first have to run the application
            //(ctrl + F5) and then you can check the database.
            context.Entries.Add(new Entry() { Description = "test", IsExpense = false, Value = 10.11});
        }
    }
}
