using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracking.Models.cf
{
    public class Expense
    {
        public string ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public decimal ExpenseValue { get; set; }
        public DateTime Date { get; set; }
        public String DateString
        {
            get
            {
                return this.Date.ToString("MMMM dd , yyyy");
            }
        }
    }
}