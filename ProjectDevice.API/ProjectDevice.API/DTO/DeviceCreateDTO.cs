using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.DTO
{
    public class DeviceCreateDTO
    {

        [Required(ErrorMessage = "name field is required")]
        [MaxLength(50, ErrorMessage = "Name lenght must be less than 50") ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required")]
        [MaxLength(1000, ErrorMessage = "Description lenght must be less than 1000")]
        public string Description { get; set; }
        [AllowNull]
        public IFormFile Foto { get; set; }
        [AllowNull]
        public IFormFile Document { get; set; }

    }
}
