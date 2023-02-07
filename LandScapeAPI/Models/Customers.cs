using System.ComponentModel.DataAnnotations;

namespace LandScapeAPI.Models

{
    public class Customers
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? status { get; set; }
        public DateTime? nextServiceDate { get; set; }

    }
}
