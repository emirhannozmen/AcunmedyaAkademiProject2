using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            ViewData["ActivePage"] = "Blog";
            var values = context.Testimonials.ToList();
            return View(values);
        }
    }
}