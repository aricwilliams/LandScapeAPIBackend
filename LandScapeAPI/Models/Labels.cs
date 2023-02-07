using System.ComponentModel.DataAnnotations;

namespace LandScapeAPI.Models
{
    public class Labels
    {
        [Key]
        public int id { get; set; }
        public string? prospect { get; set; }
        public string? customer { get; set; }
        public string? weekly { get; set; }
        public string? biWeekly { get; set; }
    }
}
