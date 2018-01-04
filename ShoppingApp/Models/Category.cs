using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Title is Required")]
        public string Name { get; set; }
        public string ImagePath { get; set; }   
    }
}