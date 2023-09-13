using ProjectDevice.API.Middlewares.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.Models
{
    [Table(name: "devices")]
    public class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "device_id")]
        public Guid DeviceId { get; set; }
        
        [Column(name: "name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }
        
        [Column(name: "description")]
        [StringLength(1000)]
        [Required(ErrorMessage = "Description field is required")]
        public string Description { get; set; }
        
        [Column(name: "foto_path")]
        [StringLength(400)]
        [AllowNull]
        public string FotoPath { get; set; }
        
        
        [Column(name: "document_path")]
        [StringLength(400)]
        [AllowNull]
        public string DocumentPath { get; set; }

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    }
   
}
