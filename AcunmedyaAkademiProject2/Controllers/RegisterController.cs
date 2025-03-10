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
    public class RegisterController : Controller
    {
        SweetContext context = new SweetContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            if (ModelState.IsValid)
            {
                var user = context.Admins.FirstOrDefault(x => x.Username == p.Username);

                if (user == null)
                {
                    context.Admins.Add(p);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                
            }

            return View();
        }
    }
}