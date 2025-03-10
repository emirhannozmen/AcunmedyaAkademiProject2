using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminContactController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult ContactList()
        {
            var values = context.Infoes.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = context.Infoes.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(Info info)
        {
            var contactUpdate = context.Infoes.Find(info.InfoId);
            contactUpdate.Email = info.Email;
            contactUpdate.Location = info.Location;
            contactUpdate.Phone = info.Phone;
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}