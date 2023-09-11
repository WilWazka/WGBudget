using WGBudget.Entities.Interfaces.TransactionCategory;

namespace WGBudget.Entities.Messages.TransactionCategory
{
    public class TransactionCategoryListRequest : ISimpleFilterTransactionCategory
    {
        public string? Text { get; set; }
        public int? CategoryType { get; set; }
    }
}
