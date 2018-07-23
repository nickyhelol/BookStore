using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }       //Add shipped property to Order

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your address ")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your state")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
