using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
//    [Authorize]
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        public ActionResult Index()
        {
            var product = _context.Products.Include(c => c.Subcategory).ToList();
            return View("Index",product);
        }
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Product = new Product(),
                Categories = _context.Categories.ToList(),
                Subcategories = _context.Subcategories.ToList()

            };
            return View("ProductForm",viewModel);
        }
        public ActionResult GetSubcategory(int categoryId)
        {
            var subcategory = _context.Subcategories.Where(m => m.CategoryId == categoryId).ToList();
            SelectList subcategoryObj = new SelectList(subcategory, "SubcategoryId", "Name",0);
            return Json(subcategory);
        }
        [HttpPost]

        public ActionResult Save(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductForm", viewModel);
            }
            string fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFileBase1.FileName);
            string extension = Path.GetExtension(viewModel.ImageFileBase1.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            viewModel.Product.ImagePath1 = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
            viewModel.ImageFileBase1.SaveAs(fileName);
            fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFileBase2.FileName);
            extension = Path.GetExtension(viewModel.ImageFileBase2.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            viewModel.Product.ImagePath2 = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
            viewModel.ImageFileBase2.SaveAs(fileName);
            _context.Products.Add(viewModel.Product);
            _context.SaveChanges();
            var product = _context.Products.Include(c => c.Subcategory).ToList();
            return View("Index", product);
        }

    }
}