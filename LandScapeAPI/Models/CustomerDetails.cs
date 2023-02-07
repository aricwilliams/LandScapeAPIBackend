using System.ComponentModel.DataAnnotations;

namespace LandScapeAPI.Models
{
    public class CustomerDetails
    {
        [Key]
        public int id { get; set; }
        public string? detailOwner { get; set; }
        public DateTime? createdDate { get; set; }
        public string? detailNotes { get; set; }
           
    }
}

