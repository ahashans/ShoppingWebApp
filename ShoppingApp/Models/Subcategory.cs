using System.Collections.Generic;

namespace ShoppingApp.Models
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string Name { get; set; }

        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}