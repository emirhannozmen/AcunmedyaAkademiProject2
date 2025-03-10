using AcunmedyaAkademiProject2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiProject2.Controllers
{
    public class AdminStatisticController : Controller
    {
        SweetContext context = new SweetContext();

        public ActionResult StatisticList()
        {
            // Kategorilerin sayısı
            ViewBag.categoryCount = GetCategoryCount();

            // Ürünlerin sayısı
            ViewBag.productCount = GetProductCount();

            // Referansların sayısı
            ViewBag.testimonialsCount = GetTestimonialsCount();

            // Son Mesaj Gelen Kişi
            ViewBag.lastMessage = GetLastMessage();

            // En yüksek fiyatlı ürün
            ViewBag.maxPrice = GetMaxPriceProductName();

            // Hizmetlerin sayısı
            ViewBag.serviceCount = GetServiceCount();

            // Admin kullanıcı sayısı
            ViewBag.userCount = GetUserCount();

            // Ürünlerin ortalama fiyatı
            ViewBag.productAvg = GetAverageProductPrice();

            // En düşük fiyatlı ürün
            ViewBag.minPrice = GetMinPriceProductName();

            // Ürünlerin toplam fiyatı
            ViewBag.totalProduct = GetTotalProductPrice();

            // Son eklenen ürün
            ViewBag.lastProduct = GetLastProduct();

            // En çok ürünü olan kategori
            ViewBag.mostProductCategory = GetMostProductCategory();

            var values = context.Products.ToList();
            return View(values);
        }

        // Yardımcı metodlar

        private string GetCategoryCount()
        {
            return context.Categories.Count().ToString();
        }

        private string GetProductCount()
        {
            return context.Products.Count().ToString();
        }

        private string GetTestimonialsCount()
        {
            return context.Testimonials.Count().ToString();
        }

        private string GetLastMessage()
        {
            return context.Messages
                .OrderByDescending(x => x.MessageId)
                .Select(x => x.NameSurname)
                .FirstOrDefault();
        }

        private string GetMaxPriceProductName()
        {
            return context.Products
                .OrderByDescending(x => x.Price)
                .Select(x => x.ProductName)
                .FirstOrDefault();
        }

        private string GetServiceCount()
        {
            return context.Services.Count().ToString();
        }

        private string GetUserCount()
        {
            return context.Admins.Count().ToString();
        }

        private string GetAverageProductPrice()
        {
            return context.Products.Average(x => x.Price).ToString("F2");
        }

        private string GetMinPriceProductName()
        {
            return context.Products
                .OrderBy(x => x.Price)
                .Select(x => x.ProductName)
                .FirstOrDefault();
        }

        private string GetTotalProductPrice()
        {
            return context.Products.Sum(x => x.Price).ToString();
        }

        private string GetLastProduct()
        {
            return context.Products
                .OrderByDescending(x => x.ProductId)
                .Select(x => x.ProductName)
                .FirstOrDefault();
        }

        private string GetMostProductCategory()
        {
            var mostProductCategoryId = context.Products
                .GroupBy(p => p.CategoryId)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()?
                .Key;

            var mostProductCategoryName = context.Categories
                .Where(c => c.CategoryId == mostProductCategoryId)
                .Select(c => c.CategoryName)
                .FirstOrDefault();

            return mostProductCategoryName;
        }

        private List<string> GetDistinctCategories()
        {
            return context.Categories
                .Select(x => x.CategoryName)
                .Distinct()
                .ToList();
        }
    }
}