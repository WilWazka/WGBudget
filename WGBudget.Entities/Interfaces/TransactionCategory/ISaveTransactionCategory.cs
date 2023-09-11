using WGBudget.Entities.Interfaces.Common;
using RecordType = WGBudget.Entities.Data.Category;

namespace WGBudget.Entities.Interfaces.TransactionCategory
{
    public interface ISaveTransactionCategory : ISaveRecord<RecordType, int>
    {
    }
}
