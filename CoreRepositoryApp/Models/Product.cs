using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

    }
}
