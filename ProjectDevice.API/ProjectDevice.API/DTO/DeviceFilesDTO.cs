using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.DTO
{
    public class DeviceFilesDTO
    {
        public IFormFile Foto { get; set; }
        public IFormFile Document { get; set; }
    }
}
