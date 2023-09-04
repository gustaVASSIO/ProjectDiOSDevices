using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDevice.API.Models
{
    [Table(name: "devices")]
    public class Device
    {
        [Column(name: "deviceId")]
        [StringLength(80)]
        public string DeviceId { get; set; }
        
        [Column(name: "name")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Column(name: "description")]
        [StringLength(400)]
        public string Description { get; set; }
        
        [Column(name: "foto_path")]
        [StringLength(80)]
        [AllowNull]
        public string FotoPath { get; set; }
        
        
        [Column(name: "document_path")]
        [StringLength(80)]
        [AllowNull]
        public string DocumentPath { get; set; }

        public Device()
        {
            DeviceId = Guid.NewGuid().ToString();
        }
    }
   
}
