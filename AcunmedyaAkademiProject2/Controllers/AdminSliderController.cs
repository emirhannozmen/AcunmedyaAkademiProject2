using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminSliderController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult SliderList()
        {
            var values = context.Sliders.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlider(Slider slider)
        {
            context.Sliders.Add(slider);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        public ActionResult DeleteSlider(int id)
        {
            var slider = context.Sliders.Find(id);
            context.Sliders.Remove(slider);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var slider = context.Sliders.Find(id);
            return View(slider);
        }
        [HttpPost]
        public ActionResult UpdateSlider(Slider slider)
        {
            var sliderUpdate = context.Sliders.Find(slider.SliderId);
            sliderUpdate.Title = slider.Title;
            sliderUpdate.Description = slider.Description;
            sliderUpdate.ImageUrl = slider.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
    }
}