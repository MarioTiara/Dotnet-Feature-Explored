using System.ComponentModel.DataAnnotations;

namespace PesonalPhotos.Models
{
    public class PhotoUploadViewModel
    {
        [Required(ErrorMessage ="Please enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose a photo!")]
        public IFormFile file { get; set; }
    }
}
