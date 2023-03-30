using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Models
{

    public class JobsM
    {
        [Key]
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public decimal EstimatedPrice { get; set; }
        public decimal TruePrice { get; set; }
        public int CustomerId { get; set; }
        public List<ChatMessageM>? ChatMessages { get; set; }
       
    }
}
