using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class OrderItem

    {
        [Key]
        public int OrderItemId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }



        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }


        public int OrderId { get; set; } // ForeignKey OrderId
       
        public virtual Order Order { get; set; }

    }
}
