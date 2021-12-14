using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class SaleController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale s)
        {
            db.Sales.Add(s);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");

        }

        [HttpGet]
        public ActionResult UpdateSale(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }
        [HttpPost]
        public ActionResult UpdateSale(int id, Sale s)
        {
            Sale sl = db.Sales.Where(x => x.id == id).SingleOrDefault();
            sl.Sale_product = s.Sale_product;
            sl.Sale_qnty =s.Sale_qnty;
            sl.Sale_date = s.Sale_date;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult DeleteSale(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult DeleteSale(int id, Sale s)
        {
            db.Sales.Remove(db.Sales.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult SaleDetails(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

    }
}