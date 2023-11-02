using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2MVCEmpty.Models
{
    public class PersonCtx:DbContext
    {

        public DbSet<Person> PersonList { get; set; }


        public PersonCtx():base("dbCon")
        {
            
        }

    }
}