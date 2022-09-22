using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class StockAvailability
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product product { get; set; }

        public int Quantity { get; set; }
        public string Status { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }


       
    }
}
