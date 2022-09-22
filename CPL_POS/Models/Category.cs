using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        [Required, StringLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }

      

        [Required]
        public string ModifiedBy { get; set; }

        //public ICollection<SubCategory> SubCategories { get; set; }
        //public ICollection<Product> Products { get; set; }
       
    }
}
