using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ExpensesAPI.Models;

namespace ExpensesAPI.Data
{
    //Once you have a model, the primary class your application interacts
    //with is the DbContext class (which we named AppDbContext) which is often referred to as the context class.
    //You use the DbContext associated to a model in order to write and execute queries,
    //materialize query results as entity objects, track changes that are made to those entity objects,
    //persist object changes back to the database, bind objects in memory to UI controls.
    //We will use EntityFramework (EF) to work with data. In order to use EF to query, insert, update, and delete
    //data using .NET objects, we first need to create a model which maps the entities and relationships that are
    //defined in your model to tables in a database. Here, our model is the Entry class that we created.
    //The AppDbContext class is the data layer which will be used to work with data. To see how to setup this class
    //in the beginning (with nothing in it), check out the folder #5 Configuring DbContext where you will find the
    //instructions on how to install the EntityFramework for this project.
    public class AppDbContext : DbContext
    {
        //This represents a table of our entries.
        public DbSet<Entry> Entries { get; set; }

        //Creating a constuctor and getting a connection stream from our database.
        //We first created the database, then added the necessary information in the Web.config file
        //in the connectionStrings tags. Check out the folder #6 Configuring a database for more details.
        public AppDbContext() : base("name=ExpensesDb")
        {

        }
    }
}