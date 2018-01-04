using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class SubcategoryController : Controller
    {
        private ApplicationDbContext _context;

        public SubcategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Subcategory
        public ActionResult Index()
        {
            var subCategory = _context.Subcategories.Include(c=>c.Category).ToList();
            return View(subCategory);
        }
        public ActionResult Create()
        {
            var viewModel = new SubcategoryViewModel
            {
                Subcategory = new Subcategory(),
                Categories = _context.Categories.ToList()

            };
            return View("SubcategoryForm",viewModel);
        }
        public ActionResult Save(SubcategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SubcategoryForm",viewModel);
            }
            string fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFileBase.FileName);
            string extension = Path.GetExtension(viewModel.ImageFileBase.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            viewModel.Subcategory.ImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
            viewModel.ImageFileBase.SaveAs(fileName);
            _context.Subcategories.Add(viewModel.Subcategory);
            _context.SaveChanges();
            var subCategory = _context.Subcategories.ToList();
            return View("Index",subCategory);
        }

    }
}