using System.Xml.Linq;
using WGBudget.Entities.Interfaces.Common;
using RecordType = WGBudget.Entities.Data.Category;

namespace WGBudget.Entities.Interfaces.TransactionCategory
{
    public interface IRetrieveTransactionCategory : IRetrieveRecord<RecordType, int>
    {
    }
}
