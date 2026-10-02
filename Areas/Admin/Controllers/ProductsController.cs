using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Mapster;
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
            ViewBag.Categories = context.Categories.ToList();
            return View(new CreateProductViewModel());
        }
        public IActionResult Store(CreateProductViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();
                return View("Create", request);
            }
            var product = request.Adapt<Products>();
            var extension = Path.GetExtension(request.MainImage.FileName);
            var fileName = Guid.NewGuid().ToString()+extension;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images","products");
           if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
           var filePath = Path.Combine(folderPath, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                request.MainImage.CopyTo(stream);
            }
            product.MainImage = fileName;
            context.Products.Add(product);
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
