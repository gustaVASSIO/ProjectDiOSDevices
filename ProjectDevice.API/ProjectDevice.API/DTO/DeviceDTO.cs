using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.DTO
{
    public class DeviceDTO
    {
        public Guid DeviceId { get; set; }

        [Required(ErrorMessage = "name field is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "description field is required")]
        public string Description { get; set; }

        [AllowNull]
        public string FotoPath { get; set; }

        [AllowNull]
        public string DocumentPath { get; set; }

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();


    }
}
