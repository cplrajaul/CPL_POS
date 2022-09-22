using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPL_POS.ViewModel
{
    public class BrandImageViewModel
    {
        [NotMapped]

        [Display(Name = "Image")]
        public IFormFile BrandPicture { get; set; }
    }
}
