using System;
using System.ComponentModel.DataAnnotations;

namespace CPL_POS.ViewModel
{
    public class BrandViewModel:BrandEditImageViewModel
    {

        [Required, StringLength(50)]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }



        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }


    }
}
