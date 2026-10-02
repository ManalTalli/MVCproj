using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext ();
        public IActionResult Index()
        {
            //var categoriesVM = context.Categories.Select(c=>new CategoryViewModel
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    Status = c.Status,
            //}).ToList();

             var categoriesVM =context.Categories.ToList().Adapt<List<CategoryViewModel>> ();

            return View(categoriesVM);
        }
        public IActionResult Create()
        {
            return View(new CreateCategoryViewModels());
        }
        public IActionResult Store(CreateCategoryViewModels request)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", request);
            }
            //var category = new Category
            //{
            //    Name = request.Name,
            //    Status = request.Status,
            //};
            var category = request.Adapt<Category>();
            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if(category == null)
            {
                return RedirectToAction("Index");
            }
            else { 
            context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {
            var category =context.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            //var model = new EditCategoryViewModels
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //    Status = category.Status,
            //};
            var model = category.Adapt<EditCategoryViewModels>();
                return View(model);
            
        }
        public IActionResult Update(EditCategoryViewModels category)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit",category);
            }
            var categoreis = context.Categories.Find(category.Id);
            if (categoreis == null) {
                return NotFound();
            }
            //category.Name = categoreis.Name;
            //category.Status = categoreis.Status;
            category.Adapt(categoreis);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
