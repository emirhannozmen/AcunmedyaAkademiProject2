using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminLayoutController : Controller
    {
        SweetContext context = new SweetContext();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeaderLeft()
        {
            ViewBag.unreadMessageCount = context.Messages.Count(x => x.IsRead == false);
            var values = context.Messages.Where(x => x.IsRead == false).ToList();
            return PartialView(values);
        }
    }
}