using WGBudget.Entities.Interfaces.Transaction;

namespace WGBudget.Data.Repositories
{
    public interface ITransactionRepository : ISaveTransaction, IUpdateTransaction, IDeleteTransaction, IRetrieveTransaction
    {
    }
}
