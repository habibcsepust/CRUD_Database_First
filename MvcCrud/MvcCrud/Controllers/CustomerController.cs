using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;
using System.Data.Entity;

namespace MvcCrud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Customers.ToList());
            }
                
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var customer = dbModels.Customers.Where(c => c.Id == id).FirstOrDefault();
                return View(customer);
            }
                
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Customers.Add(customer);
                    dbModels.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var customer = dbModels.Customers.Where(c => c.Id == id).FirstOrDefault();
                return View(customer);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(customer).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var customer = dbModels.Customers.Where(c => c.Id == id).FirstOrDefault();
                return View(customer);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModels = new DbModels())
                {
                    Customer customer = dbModels.Customers.Where(c => c.Id == id).FirstOrDefault();
                    dbModels.Customers.Remove(customer);
                    dbModels.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
