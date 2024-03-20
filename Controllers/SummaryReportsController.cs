using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1FinalCapstone.Models;

namespace _1FinalCapstone.Controllers
{
    public class SummaryReportsController : Controller
    {
        private Entities db = new Entities();

        // GET: SummaryReports
        public ActionResult Index()
        {
            return View(db.CompletedOrders.ToList());
        }

        // GET: SummaryReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedOrders completedOrders = db.CompletedOrders.Find(id);
            if (completedOrders == null)
            {
                return HttpNotFound();
            }
            return View(completedOrders);
        }

        // GET: SummaryReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SummaryReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompletedId,OrderName,OrderQuantity,OrderPrice,TotalPrice,FirstName,LastName,Email,Address,ContactNumber,PaymentMode,CustomerAccountNumber,OrderStatus,CheckoutDate,AcceptedDate,CompletedDate")] CompletedOrders completedOrders)
        {
            if (ModelState.IsValid)
            {
                db.CompletedOrders.Add(completedOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(completedOrders);
        }

        // GET: SummaryReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedOrders completedOrders = db.CompletedOrders.Find(id);
            if (completedOrders == null)
            {
                return HttpNotFound();
            }
            return View(completedOrders);
        }

        // POST: SummaryReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompletedId,OrderName,OrderQuantity,OrderPrice,TotalPrice,FirstName,LastName,Email,Address,ContactNumber,PaymentMode,CustomerAccountNumber,OrderStatus,CheckoutDate,AcceptedDate,CompletedDate")] CompletedOrders completedOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(completedOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(completedOrders);
        }

        // GET: SummaryReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedOrders completedOrders = db.CompletedOrders.Find(id);
            if (completedOrders == null)
            {
                return HttpNotFound();
            }
            return View(completedOrders);
        }

        // POST: SummaryReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompletedOrders completedOrders = db.CompletedOrders.Find(id);
            db.CompletedOrders.Remove(completedOrders);
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
