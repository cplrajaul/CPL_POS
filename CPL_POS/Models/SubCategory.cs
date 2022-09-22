using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "SubCategory Name")]
        public string SubCategoryName { get; set; }


        [Required, StringLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }



        [Required]
        public DateTime CreatedOn { get; set; }



        [Required]
        public string ModifiedBy { get; set; }


    }
}
