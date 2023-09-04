using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.DTO
{
    public class TestCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [AllowNull]
        public IFormFile Foto { get; set; }
        [AllowNull]
        public  IFormFile Document { get; set; }
    }
}
