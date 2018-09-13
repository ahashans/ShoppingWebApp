using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        [Required(ErrorMessage = "Subcategory Name is Required")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        [Display(Name="Category Name")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}