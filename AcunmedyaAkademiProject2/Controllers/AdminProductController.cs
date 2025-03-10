using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminProductController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.v = categories;                                   
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = context.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.Description = product.Description;
            value.Price = product.Price;
            value.ImageUrl = product.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}