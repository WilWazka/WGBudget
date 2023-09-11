using WGBudget.Entities.Interfaces.Common;
using RecordType = WGBudget.Entities.Data.Category;

namespace WGBudget.Entities.Interfaces.TransactionCategory
{
    public interface ISimpleFilterTransactionCategory : IFilter<RecordType>
    {
        public string? Text { get; set; }
        public int? CategoryType { get; set; }
        //public int? UserId { get; set;}
    }
}
