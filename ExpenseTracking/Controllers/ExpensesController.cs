﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpenseTracking.Models.cf;

namespace ExpenseTracking.Controllers
{
    public class ExpensesController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Expenses
        public ActionResult Index(string sortOrder, string searchString, DateTime? startDate, DateTime? endDate)
        {
            decimal total = 0.0m;

            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ValueSortParam = sortOrder == "Value" ? "value_desc" : "Value";

            var expenses = from s in db.Expenses
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                expenses = expenses.Where(s => s.ExpenseName.Contains(searchString));
            }
            if (startDate.HasValue)
            {
                expenses = expenses.Where(x => x.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                expenses = expenses.Where(x => x.Date <= endDate.Value);
            }
            if (startDate.HasValue && endDate.HasValue)
            {
                expenses = (expenses.Where(x => startDate >= x.Date && x.Date <= endDate));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    expenses = expenses.OrderByDescending(s => s.ExpenseName);
                    break;
                case "Name":
                    expenses = expenses.OrderBy(s => s.Date);
                    break;
                case "Date":
                    expenses = expenses.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    expenses = expenses.OrderByDescending(s => s.Date);
                    break;
                case "value_desc":
                    expenses = expenses.OrderByDescending(s => s.ExpenseValue);
                    break;
                case "Value":
                    expenses = expenses.OrderBy(s => s.ExpenseValue);
                    break;
                default:
                    expenses = expenses.OrderBy(s => s.Date);
                    break;
            }

            foreach (Expense expense in expenses)
            {
                total += expense.ExpenseValue;
            }
            ViewBag.Message = total;

            return View(expenses.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
                return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseId,ExpenseName,ExpenseValue,Date")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseId,ExpenseName,ExpenseValue,Date")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
