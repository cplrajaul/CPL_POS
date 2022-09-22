using CPL_POS.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CPL_POS.ViewModel
{
    public class ProductViewModel: ProductEditImageViewModel
    {

        [Required, StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }



        [Required, StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }




        [Required, StringLength(50)]
        [Display(Name = "Price")]
        public string Price { get; set; }




        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }



        [Required]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }






        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }



        [Display(Name = "Category Name")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }



        [Required(ErrorMessage = "Please Select SubCategory")]
        public int SubCategoryId { get; set; }



        [Display(Name = "SubCategory Name")]
        [DataType(DataType.Text)]
        public string SubCategoryName { get; set; }


        [Required(ErrorMessage = "Please Select Brand")]
        public int BrandId { get; set; }



        [Display(Name = "Brand Name")]
        [DataType(DataType.Text)]
        public string BrandName { get; set; }
    }
}
