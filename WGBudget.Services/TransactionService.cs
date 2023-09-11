using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBudget.Data.Repositories;
using RecordType = WGBudget.Entities.Data.Transaction;
using WGBudget.Entities.Messages.Transaction;
using Azure.Core;
using Microsoft.AspNetCore.Identity;

namespace WGBudget.Services
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepo)
        {
            this.transactionRepository = transactionRepo;
        }

        public async Task<int> CreateTransactionAsync(TransactionCreateRequest request)
        {
            var data = new TransactionDto
            {
                Amount = request.Amount,
                Description = request.Description,
                TransactionCategoryId = request.TransactionCategoryId,
                UserID = request.UserID,
                CreatedAt = DateTime.UtcNow,
                TransactionDate = request.TransactionDate
            };
            var result = transactionRepository.Save((RecordType)data);
            return await Task.FromResult(result);
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var data = new TransactionDto
            {
                ID = transactionId
            };
            var result = transactionRepository.Delete((RecordType)data);
            return await Task.FromResult(result);
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(int transactionId)
        {
            var result = transactionRepository.GetSingle(transactionId);
            return await Task.FromResult((TransactionDto)result);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync(TransactionListRequest filterRequest)
        {
            //filterRequest.UserId = userId;
            var result = transactionRepository.GetList(filterRequest);
            return await Task.FromResult(result.Cast<TransactionDto>());
        }

        public async Task<TransactionDto> UpdateTransactionAsync(TransactionUpdateRequest request)
        {
            var data = new TransactionDto
            {
                ID = request.ID,
                Amount = request.Amount,
                Description = request.Description,
                TransactionCategoryId = request.TransactionCategoryId,
                UserID = request.UserID,
                TransactionDate = request.TransactionDate
            };
            var result = transactionRepository.Update((RecordType)data);
            if (result == true)
                return await Task.FromResult(data);
            throw new Exception($"There was an error updating the record with id: {request.ID}");
        }
    }
}
