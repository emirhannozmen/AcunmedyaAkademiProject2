using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminTestimonialController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            context.Testimonials.Remove(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            return View(testimonial);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var testimonialUpdate = context.Testimonials.Find(testimonial.TestimonialId);
            testimonialUpdate.NameSurname = testimonial.NameSurname;
            testimonialUpdate.CommentDetail = testimonial.CommentDetail;
            testimonialUpdate.ImageUrl = testimonial.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}