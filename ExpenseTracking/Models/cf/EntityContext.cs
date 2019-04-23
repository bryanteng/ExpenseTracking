using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExpenseTracking.Models.cf
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=cfConnectionString") { }
        public DbSet<Expense> Expenses { get; set; }
    }
}