using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectDevice.API.Models
{
    [Table(name:"subscriptions")]
    public class Subscription
    {
        [Column(name:"subscription_id")]
        public int SubscriptionId { get; set; }

        [Column(name:"title")]
        [StringLength(300)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Column(name:"description")]
        [StringLength(400)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Column(name:"device_id")]
        [Required(ErrorMessage = "The subscription must be associate with a device")]
        public Guid DeviceId { get; set; }
        [JsonIgnore]
        public Device Device { get; set; }


    }
}
