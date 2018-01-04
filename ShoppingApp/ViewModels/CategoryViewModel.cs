using System.Web;
using ShoppingApp.Models;

namespace ShoppingApp.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public HttpPostedFileBase ImageFileBase { get; set; }
    }
}