using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using lucky_number_database.Models; //created from the bulb

namespace bit285_lucky_number_database.Models
{
    public class LuckyNumberDbContext : DbContext
    {
        public LuckyNumberDbContext() : base("LuckyNumber") { } //going to use db context but not builfing it must execute save changes

        public DbSet <LuckyNumber> LuckyNumbers { get; set; } //each record is a luccky number. each record will have the same properties
    }
}