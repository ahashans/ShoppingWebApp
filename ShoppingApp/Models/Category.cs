using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ShoppingApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Title is Required")]
        [StringLength(450)]
        [Index(IsUnique = true)] 
        [Remote("CheckCategoryName","Category",HttpMethod = "POST",ErrorMessage = "A category with the given name already exists. Please enter a different name")]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}