using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Title is Required")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}