using WGBudget.Entities.Interfaces.TransactionCategory;

namespace WGBudget.Data.Repositories
{
    public interface ITransactionCategoryRepository : ISaveTransactionCategory, IUpdateTransactionCategory, IDeleteTransactionCategory, IRetrieveTransactionCategory
    {
    }
}
