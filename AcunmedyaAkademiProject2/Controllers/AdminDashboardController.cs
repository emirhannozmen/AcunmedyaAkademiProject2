using AcunmedyaAkademiProject2.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    [AllowAnonymous]
    public class AdminDashboardController : Controller
    {
        SweetContext context = new SweetContext();

        public ActionResult Index()
        {
            var user = User.Identity.Name;
            var admin = context.Admins.FirstOrDefault(a => a.Username == user);

            return View(admin);
        }

        [HttpGet]
        public JsonResult GetChart()
        {
            var data = context.Products
                .GroupBy(p => p.Category.CategoryName)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count()
                })
                .ToList();

            var chartData = new List<object>
            {
                new object[] { "Kategori Adı", "Ürün Sayısı" }
            };

            foreach (var item in data)
            {
                chartData.Add(new object[] { item.CategoryName, item.ProductCount });
            }

            return Json(chartData, JsonRequestBehavior.AllowGet);
        }
    }
}