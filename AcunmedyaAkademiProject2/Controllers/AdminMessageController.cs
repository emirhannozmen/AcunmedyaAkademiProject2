using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminMessageController : Controller
    {
        SweetContext context = new SweetContext();
        public ActionResult MessageList()
        {
            var values = context.Messages.ToList();
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = context.Messages.Find(id);
            context.Messages.Remove(message);
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }
        public ActionResult ReadToTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }
        public ActionResult ReadToFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }
        public ActionResult MessageDetail(int id)
        {
            var message = context.Messages.FirstOrDefault(m => m.MessageId == id);
            return View(message);
        }
    }
}