using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminServiceController : Controller
    {
        SweetContext context = new SweetContext();

        public ActionResult ServiceList()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            service.Status = true;
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult DeleteService(int id)
        {
            var service = context.Services.Find(id);
            context.Services.Remove(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = context.Services.Find(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var serviceUpdate = context.Services.Find(service.ServiceId);
            serviceUpdate.Title = service.Title;
            serviceUpdate.Description = service.Description;
            serviceUpdate.Icon = service.Icon;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}