using System.ComponentModel.DataAnnotations;
using WGBudget.Entities.Messages.Common;

namespace WGBudget.Entities.Messages.Transaction
{
    public class TransactionListResponse : PagedList<TransactionDto>
    {
    }
}
