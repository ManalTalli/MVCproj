using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories=context.Categories.ToList();
            return View(new Products());
        }
        public IActionResult Store(Products products)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", products);
            }
            context.Products.Add(products);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var products = context.Products.Find(id);
            if (products == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                context.Products.Remove(products);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {
            var products = context.Products.Find(id);
            if (products == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(products);
            }
        }
        public IActionResult Update(Products products)
        {
            var product = context.Products.Update(products);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
