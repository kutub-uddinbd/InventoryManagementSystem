using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");

        }

        [HttpGet]
        public ActionResult UpdatePurchase(int id)
        {
            Purchase pr = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdatePurchase(int id, Purchase pur)
        {
            Purchase pr = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            pr.Purchase_product = pur.Purchase_product;
            pr.Purchase_qnty = pur.Purchase_qnty;
            pr.Purchase_date = pur.Purchase_date;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            Purchase pur = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(pur);
        }
        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase pr)
        {
            db.Purchases.Remove(db.Purchases.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult PurchaseDetails(int id)
        {
            Purchase pro = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

    }
}