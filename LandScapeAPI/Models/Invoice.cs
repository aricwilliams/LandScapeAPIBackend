namespace LandScapeAPI.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int LandscapingJobId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
    }
}
