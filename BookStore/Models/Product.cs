using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter the product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the product author")]
        public string Author { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify the product category")]
        public string Category { get; set; }
    }
}
