using WGBudget.Entities.Interfaces.Common;
using RecordType = WGBudget.Entities.Data.Transaction;

namespace WGBudget.Entities.Interfaces.Transaction
{
    public interface ISimpleFilterTransaction : IFilter<RecordType>
    {
        public DateTime? TransactionDateSince { get; set; }
        public DateTime? TransactionDateUntil { get; set; }
        public string? Description { get; set; }
        public int? TransactionCategoryId { get; set; }
        public int? UserId { get; set;}
    }
}
