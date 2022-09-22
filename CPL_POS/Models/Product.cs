using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Price")]
        public string Price { get; set; }


        [Display(Name = "Image")]
        public string PhotoPath { get; set; }


        [Required]
        [Display(Name = "Created On ")]
        public DateTime CreatedOn { get; set; }



        [Required]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }


        //public int StockId { get; set; }
        public virtual StockAvailability StockAvailability { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brands { get; set; }
    }
}
