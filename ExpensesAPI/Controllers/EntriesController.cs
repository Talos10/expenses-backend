using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ExpensesAPI.Data;
using ExpensesAPI.Models;

namespace ExpensesAPI.Controllers
{
    //A controller that will communicate with the database using the context AppDbContext
    //we created in order to get all the entries from the table inside the database
    //so that it can then send it to the frontend.
    [EnableCors("http://localhost:4200", "*", "*")]
    public class EntriesController : ApiController
    {

        //Get method which will allow us to get all the entries from the database by
        //using the context that we created called AppDbContext in order to connect to the
        //database, get a list of the entries, and then returning that.
        [HttpGet]
        public IHttpActionResult GetAllEntries()
        {
            try
            {
                //Using block means that the thing defined in parenthesis will be automatically disposed
                //at the end of the using block statement. The object must implement the IDisposable interface
                //so that the using block can call the dispose() method on the object at the end of the block.
                //The object doesn't have to be instantiated in the parenthesis of the using block. It can also
                //be instantiated just before the using block and the object will still be disposed of if it is
                //used in the using block.
                using (var context = new AppDbContext())
                {
                    //or do List<Models.Entry> entries = context.Entries.ToList();
                    var entries = context.Entries.ToList();
                    return Ok(entries);
                }
            }
            catch (Exception e) //If we fail to connect to the db with our connection string, display the exception to the user.
            {
                return BadRequest(e.Message);
            }

        }

        //Get method which will allow us to get the entry that has a primary key that
        //corresponds to the given id.
        [HttpGet]
        public IHttpActionResult GetEntry(int id)
        {
            try
            {
                //Using block means that the thing defined in parenthesis will be automatically disposed
                //at the end of the using block statement. The object must implement the IDisposable interface
                //so that the using block can call the dispose() method on the object at the end of the block.
                //The object doesn't have to be instantiated in the parenthesis of the using block. It can also
                //be instantiated just before the using block and the object will still be disposed of if it is
                //used in the using block.
                using (var context = new AppDbContext())
                {
                    var entry = context.Entries.FirstOrDefault(n => n.Id == id);

                    if (entry == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(entry);
                    }     
                }
            }
            catch (Exception e) //If we fail to connect to the db with our connection string, display the exception to the user.
            {
                return BadRequest(e.Message);
            }

        }

        //Post method which allows the user to add an entry to the database.
        [HttpPost]
        public IHttpActionResult PostEntry([FromBody]Entry entry)
        {
            //If the model is not valid, then return a bad request.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Put the using block in a try-catch block if something goes wrong
            //with the AppDbContext.
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entries.Add(entry);
                    context.SaveChanges();

                    return Ok("Entry was created successfully.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Put method which allows the user to update an entry in the database.
        //It's not completely a put method since we don't allow the user
        //to create an entry if the given id does not match an entry's id
        //in the database.
        [HttpPut]
        public IHttpActionResult UpdateEntry(int id, [FromBody]Entry entry)
        {
            //If the model is not valid, then return a bad request.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.Id)
            {
                return BadRequest();
            }

            //Put the using block in a try-catch block if something goes wrong
            //with the AppDbContext.
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldEntry = context.Entries.FirstOrDefault(n => n.Id == id);

                    if (oldEntry == null)
                    {
                        return NotFound();
                    }

                    //Updating the fields of the entry with the new values.
                    oldEntry.Description = entry.Description;
                    oldEntry.IsExpense = entry.IsExpense;
                    oldEntry.Value = entry.Value;

                    context.SaveChanges();

                    return Ok("Entry has been updated.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Put method which allows the user to delete an entry from the database.
        [HttpDelete]
        public IHttpActionResult DeleteEntry(int id)
        {
            //Put the using block in a try-catch block if something goes wrong
            //with the AppDbContext.
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldEntry = context.Entries.FirstOrDefault(n => n.Id == id);

                    if (oldEntry == null)
                    {
                        return NotFound();
                    }

                    context.Entries.Remove(oldEntry);

                    context.SaveChanges();

                    return Ok("Entry has been deleted.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
