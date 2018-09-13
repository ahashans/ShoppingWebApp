using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is Required!")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Price is Required!")]
        public decimal? Price{ get; set; }

        public string Size { get; set; }
        [Required(ErrorMessage = "Product Descpription is Required!")]
        [StringLength(450)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stock Count is Required")]
        public int? StockCount { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        [Required(ErrorMessage = "Product Subcategory is Required!")]
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}