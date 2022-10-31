using System.ComponentModel.DataAnnotations;

namespace CoreRepositoryApp.Models
{
    public class Product
    {
        public string Id { get; set; }
        [Required (ErrorMessage ="Please Enter your Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter your Product Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter your Product Price")]
        public decimal Price { get; set; }

    }
}
