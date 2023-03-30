using System.ComponentModel.DataAnnotations;

namespace LandScapeAPI.Models
{
    public class ChatMessageM
    {
        [Key]
        public int Id { get; set; }
        public int LandscapingJobId { get; set; }
        public string? SenderName { get; set; }
        public string? MessageText { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
