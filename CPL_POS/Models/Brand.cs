using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }


        [Display(Name = "Logo")]
        public string BrandLogo { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }


        
    }
}
