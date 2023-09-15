using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDevice.API.DTO
{
    public class SubscriptionCreatedDTO
    {

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DeviceId is required")]
        public Guid DeviceId { get; set; }
    }
}
