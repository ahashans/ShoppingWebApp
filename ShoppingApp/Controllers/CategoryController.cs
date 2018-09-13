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

        public JsonResult GetCategories()
        {
            var category = _context.Categories.ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel
            {
                Category = new Category()
            };
            return View("CategoryForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", categoryViewModel);
            }

            if (categoryViewModel.ImageFileBase != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(categoryViewModel.ImageFileBase.FileName);
                string extension = Path.GetExtension(categoryViewModel.ImageFileBase.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                categoryViewModel.Category.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                categoryViewModel.ImageFileBase.SaveAs(fileName);
            }

            _context.Categories.Add(categoryViewModel.Category);
            _context.SaveChanges();
            ModelState.Clear();
            var category = _context.Categories.ToList();
            return View("Index", category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new CategoryViewModel
            {
                Category = this._context.Categories.FirstOrDefault(c => c.CategoryId == id)
            };
            ViewBag.operation = "Edit";
            return this.View("CategoryForm", viewModel);

        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult CheckCategoryName([Bind(Prefix = "Category.Name")]string name)
        {
            var result = _context.Categories.Any(c => c.Name == name)==false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", viewModel);
            }

            if (viewModel.ImageFileBase != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFileBase.FileName);
                string extension = Path.GetExtension(viewModel.ImageFileBase.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.Category.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.ImageFileBase.SaveAs(fileName);
            }

            using (var _ctx = new ApplicationDbContext())
            {
                var cat = _ctx.Categories.FirstOrDefault(c => c.CategoryId == viewModel.Category.CategoryId);
                cat.Name = viewModel.Category.Name;
                cat.ImagePath = viewModel.Category.ImagePath;
                _ctx.SaveChanges();
            }
            ModelState.Clear();
            var category = _context.Categories.ToList();
            return this.View("Index", category);
        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c=>c.CategoryId==id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}