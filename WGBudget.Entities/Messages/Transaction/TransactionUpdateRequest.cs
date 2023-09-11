using System.ComponentModel.DataAnnotations;

namespace WGBudget.Entities.Messages.Transaction
{
    public class TransactionUpdateRequest
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int TransactionCategoryId { get; set; }
        public int UserID { get; set; }
    }
}
