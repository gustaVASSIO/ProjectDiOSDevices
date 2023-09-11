using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDevice.API.DTO
{
    public class SubscriptionCreatedDTO
    {   

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
