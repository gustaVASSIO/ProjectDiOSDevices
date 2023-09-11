using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.DTO
{
    public class DeviceCreateDTO
    {

        [Required(ErrorMessage = "name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "description field is required")]
        public string Description { get; set; }
        [AllowNull]
        public IFormFile Foto { get; set; }
        [AllowNull]
        public IFormFile Document { get; set; }
    }
}
