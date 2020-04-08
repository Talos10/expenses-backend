using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Models
{

    //A model is an object that represents the data in your application.
    //A model serves as a signature of a table in our sql server.
    //Each property that will be defined here is going to be translated into a column
    //in a table in our sql server. Each column is going to have its own data.
    //An entry has a description and so we define a property of type string.
    //An entry also has a type (income or expense) so we'll use a boolean type.
    //An entry also has a value so we'll use a double.
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        public String Description { get; set; }
        public bool IsExpense { get; set; }
        public double Value { get; set; }
    }
}