using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel
            {
                Category = new Category()
            };
            return View("CategoryForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm",categoryViewModel);
            }
            
            string fileName = Path.GetFileNameWithoutExtension(categoryViewModel.ImageFileBase.FileName);
            string extension = Path.GetExtension(categoryViewModel.ImageFileBase.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            categoryViewModel.Category.ImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images"),fileName);
            categoryViewModel.ImageFileBase.SaveAs(fileName);
            _context.Categories.Add(categoryViewModel.Category);
            _context.SaveChanges();
            ModelState.Clear();
            var category = _context.Categories.ToList();
            return View("Index",category);
        }

    }
}