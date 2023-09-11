using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBudget.Entities.Messages.Transaction;

namespace WGBudget.Services
{
    public interface ITransactionService
    {
        // Create a new budget transaction
        Task<int> CreateTransactionAsync(TransactionCreateRequest request);

        // Retrieve a budget transaction by its unique ID
        Task<TransactionDto> GetTransactionByIdAsync(int transactionId);

        // Retrieve all budget transactions using the given filter
        Task<IEnumerable<TransactionDto>> GetTransactionsAsync(TransactionListRequest filterRequest);

        // Update an existing budget transaction
        Task<TransactionDto> UpdateTransactionAsync(TransactionUpdateRequest request);

        // Delete a budget transaction by its unique ID
        Task<bool> DeleteTransactionAsync(int transactionId);
    }
}