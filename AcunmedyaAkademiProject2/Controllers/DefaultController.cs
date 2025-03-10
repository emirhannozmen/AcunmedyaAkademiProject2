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
    public class DefaultController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialSlider()
        {
            var values = context.Sliders.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialLast6Product()
        {
            var values = context.Products.OrderByDescending(x => x.ProductId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialServices()
        {
            var values = context.Services.Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialContact(Contact contact)
        {
            contact.SendDate = DateTime.Now;
            context.Contacts.Add(contact);
            context.SaveChanges();

            return PartialView();
        }
        public PartialViewResult PartialInfo()
        {
            var value = context.Infoes.FirstOrDefault();
            return PartialView(value);
        }
    }
}