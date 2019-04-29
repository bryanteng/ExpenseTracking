using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExpenseTracking.Models.cf
{
    public class Expense
    {
        public string ExpenseId { get; set; }

        [DisplayName("Expense")]
        public string ExpenseName { get; set; }

        [DisplayName("Cost")]
        public decimal ExpenseValue { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}