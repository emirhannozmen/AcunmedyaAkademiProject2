using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminAboutController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = context.Abouts.Find(id);
            context.Abouts.Remove(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = context.Abouts.Find(id);
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var aboutUpdate = context.Abouts.Find(about.AboutId);
            aboutUpdate.Title = about.Title;
            aboutUpdate.Description = about.Description;
            aboutUpdate.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}