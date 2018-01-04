using System.Collections.Generic;
using System.Web;
using ShoppingApp.Models;

namespace ShoppingApp.ViewModels
{
    public class SubcategoryViewModel
    {
        public Subcategory Subcategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public HttpPostedFileBase ImageFileBase { get; set; }   
    }
}