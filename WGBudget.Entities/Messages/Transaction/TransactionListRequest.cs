using System.ComponentModel.DataAnnotations;
using WGBudget.Entities.Interfaces.Transaction;

namespace WGBudget.Entities.Messages.Transaction
{
    public class TransactionListRequest : ISimpleFilterTransaction
    {
        public DateTime? TransactionDateSince { get; set; }
        public DateTime? TransactionDateUntil { get; set; }
        public string? Description { get; set; }
        public int? TransactionCategoryId { get; set; }
        public int? UserId { get; set; }
    }
}
