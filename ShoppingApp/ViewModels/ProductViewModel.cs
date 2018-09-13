using System.Collections.Generic;
using System.Web;
using ShoppingApp.Models;

namespace ShoppingApp.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Subcategory> Subcategories { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public HttpPostedFileBase ImageFileBase1 { get; set; }
        public HttpPostedFileBase ImageFileBase2 { get; set; }
        
    }
}