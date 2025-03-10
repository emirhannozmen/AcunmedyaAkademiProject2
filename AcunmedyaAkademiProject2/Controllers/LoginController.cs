using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AcunmedyaAkademiProject2.Context;
using AcunmedyaAkademiProject2.Entities;

namespace AcunmedyaAkademiProject2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
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
            var user = context.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(p.Username, true);
                Session["userInfo"] = p.Username;
                return RedirectToAction("Index", "AdminDashboard");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}