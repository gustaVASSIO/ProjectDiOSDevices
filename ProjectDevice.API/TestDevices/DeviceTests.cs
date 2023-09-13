using ProjectDevice.API.Middlewares.Exceptions;
using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations;

namespace TestDevices
{
    public class DeviceTests
    {

        [Fact(DisplayName = "Given invalid values for a device, when create, should throw a ValidationException")]
        public void GivenInvalideValues_WhenCreateDevice_ThenTrhowValidationException()
        {
            Assert.Throws<ValidationException>(() => GenerateInvalidDevice());
        }

        private void GenerateInvalidDevice()
        {
            var device = new Device()
            {
                DeviceId = Guid.NewGuid(),
                Name = GenerateAlfaNumericString(51),
                Description = GenerateAlfaNumericString(10),
                FotoPath = GenerateAlfaNumericString(301),
                DocumentPath = GenerateAlfaNumericString(301),
            };
            
            Validator.ValidateObject(device, new ValidationContext(device), validateAllProperties: true);

        }

        private string GenerateAlfaNumericString(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}