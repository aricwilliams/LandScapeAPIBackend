using System.ComponentModel.DataAnnotations;

namespace LandScapeAPI.Models
{
    public class Jobs
    {
        [Key]
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public decimal EstimatedPrice { get; set; }
        public decimal TruePrice { get; set; }
        public int CustomerId { get; set; }
        public List<ChatMessage>? ChatMessages { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
