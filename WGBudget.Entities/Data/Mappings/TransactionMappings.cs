using WGBudget.Entities.Messages.Transaction;

namespace WGBudget.Entities.Data
{
    public partial class Transaction
    {
        /// <summary>
        /// Explicit cast from Dto to Entity for <see cref="Transaction"/>.
        /// </summary>
        /// <param name="input"></param>
        public static explicit operator Transaction(TransactionDto input)
        {
            if (input == null) return null;

            return new Transaction
            {
                ID = input.ID ?? 0,
                Amount = input.Amount,
                CategoryID = input.TransactionCategoryId,
                Description = input.Description,
                TransactionDate = input.TransactionDate,
                CreatedAt = input.CreatedAt,
                UserID = input.UserID
            };
        }

        public static explicit operator TransactionDto(Transaction input)
        {
            if (input == null) return null;

            return new TransactionDto
            {
                ID = input.ID,
                Amount = input.Amount,
                TransactionCategoryId = input.CategoryID,
                Description = input.Description,
                TransactionDate = input.TransactionDate,
                CreatedAt = input.CreatedAt,
                UserID = input.UserID
            };
        }
    }
}