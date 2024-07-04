using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid Price format")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Invalid Price format. Only whole numbers are allowed.")]
        public int Quandity { get; set; }
    }
}