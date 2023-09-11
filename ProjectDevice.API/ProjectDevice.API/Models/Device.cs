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
        [StringLength(80)]
        public Guid DeviceId { get; set; }
        
        [Column(name: "name")]
        [StringLength(50)]
        [Required(ErrorMessage = "name field is required")]
        public string Name { get; set; }
        
        [Column(name: "description")]
        [Required(ErrorMessage = "description field is required")]
        public string Description { get; set; }
        
        [Column(name: "foto_path")]
        [StringLength(300)]
        [AllowNull]
        public string FotoPath { get; set; }
        
        
        [Column(name: "document_path")]
        [StringLength(300)]
        [AllowNull]
        public string DocumentPath { get; set; }

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    }
   
}
