using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewellMVC.Models;
namespace JewellMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        JewelDBEntities2 db = new JewelDBEntities2();
        public ActionResult ViewProduct()
        {
            return View(db.products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] product productToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            db.products.Add(productToCreate);
           db.SaveChanges();
            
            return RedirectToAction("ViewProduct");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var ProductToEdit = (from m in db.products where m.id == id select m).First();
            return View(ProductToEdit);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(product productID)
        {
            var orignalRecord = (from m in db.products where m.id ==productID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            db.Entry(orignalRecord).CurrentValues.SetValues(productID);

            db.SaveChanges();
            return RedirectToAction("ViewProduct");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(product Productid)
        {
            var d = db.products.Where(x => x.id ==Productid.id).FirstOrDefault();
            db.products.Remove(d);
            db.SaveChanges();
            return RedirectToAction("ViewProduct");
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {/*
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
               
            }*/
            return View();
        }
    }
}
