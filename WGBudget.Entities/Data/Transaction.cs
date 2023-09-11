using System.ComponentModel.DataAnnotations;

namespace WGBudget.Entities.Data
{
    public partial class Transaction
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int CategoryID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
