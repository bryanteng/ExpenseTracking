using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ExpenseTracking.Controllers
{
    public class InitController : Controller
    {
        // GET: Init
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Init()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Models.cf.EntityContext>());

            var expense = new Models.cf.Expense()
            {
                ExpenseId = "1",
                ExpenseName = "Groceries",
                ExpenseValue = 121.45m,
                Date = new DateTime(2019, 4, 1)
            };

            using (var context = new Models.cf.EntityContext())
            {
                context.Expenses.Add(expense);
                context.SaveChanges();
            }
                return View();
        }
    }
}