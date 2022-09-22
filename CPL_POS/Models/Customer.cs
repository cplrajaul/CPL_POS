using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }



        [Required]
        [StringLength(13)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required, StringLength(100)]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }

        //public ICollection<Order> orders { get; set; }
    }
}
