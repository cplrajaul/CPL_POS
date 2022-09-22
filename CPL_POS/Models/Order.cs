using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        [Required, StringLength(200)]
        [Display(Name = "Order Name")]
        public string OrderDetails { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }


        public int CustomerId { get; set; }
        public virtual Customer customer { get; set; }

        //public ICollection<OrderItem> OrderItems { get; set; }
    }
}
