using System.ComponentModel.DataAnnotations;

namespace LandScapeAPI.Models
{
    public class HomePageCard
    {
        [Key]
        public int id { get; set; }
        public string? cardTitle { get; set; } = "";
        public string? dayRange { get; set; } = "";
        public int cardTotal { get; set; }
        public int cardTotalDetail { get; set; }
        public string? cardTotalStatus { get; set; } = "";

    }
}
