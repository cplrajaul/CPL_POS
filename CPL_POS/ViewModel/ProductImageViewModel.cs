using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPL_POS.ViewModel
{
    public class ProductImageViewModel
    {
        [NotMapped]

        [Display(Name = "Product Image")]
        public IFormFile ProductPicture { get; set; }
    }
}
