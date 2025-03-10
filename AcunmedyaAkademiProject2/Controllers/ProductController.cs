using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            ViewData["ActivePage"] = "Product";
            var values = context.Products.ToList();
            return View(values);
        }
    }
}