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
    public class ContactController : Controller
    {
        SweetContext context = new SweetContext();

        [HttpGet]
        public ActionResult Index()
        {
            ViewData["ActivePage"] = "Contact";
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Now;
            context.Contacts.Add(contact);
            context.SaveChanges();

            return View();
        }

        public PartialViewResult PartialInfo()
        {
            var value = context.Infoes.FirstOrDefault();
            return PartialView(value);
        }
    }
}