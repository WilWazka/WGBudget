using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using WGBudget.Entities.Data;
using WGBudget.Entities.Interfaces.Common;
using WGBudget.Entities.Interfaces.Transaction;
using static Dapper.SqlMapper;

namespace WGBudget.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly DapperDataContext Context;
        public TransactionRepository(DapperDataContext context_)
        {
            this.Context = context_;
        }

        public bool Delete(Transaction data)
        {
            try
            {
                using (var conn = Context.CreateConnection())
                {
                    return conn.Delete(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Transaction> GetList(IFilter<Transaction> filterData)
        {
            var filter = (filterData as ISimpleFilterTransaction);
            try
            {
                if (filter == null)
                    throw new ArgumentException("Filter does not implement ISimpleFilterTransaction interface.", nameof(filterData));

                var query = string.Concat("SELECT  ID, TransactionDate, Description, Amount, CategoryID, UserID, CreatedAt, ModifiedAt ",
                    " FROM  Transaction ",
                    " WHERE (@UserId IS NULL OR UserId = @UserId);",
                    " AND (@TransactionDateSince IS NULL OR TransactionDate >= @TransactionDateSince);",
                    " AND (@TransactionDateUntil IS NULL OR TransactionDate <= @TransactionDateUntil);",
                    " AND (@Description IS NULL OR Description LIKE @Description);",
                    " AND (@TransactionCategoryId IS NULL OR CategoryID = @TransactionCategoryId);");

                var queryParameters = new DynamicParameters();
                if (filter.UserId.HasValue)
                    queryParameters.Add("@UserId", filter.UserId);
                else
                    queryParameters.Add("@UserId", DBNull.Value, DbType.Int32);
                if (filter.TransactionDateSince.HasValue)
                    queryParameters.Add("@TransactionDateSince", filter.TransactionDateSince);
                else
                    queryParameters.Add("@TransactionDateSince", DBNull.Value, DbType.Date);
                if (filter.TransactionDateUntil.HasValue)
                    queryParameters.Add("@TransactionDateUntil", filter.TransactionDateUntil);
                else
                    queryParameters.Add("@TransactionDateUntil", DBNull.Value, DbType.Date);
                if (filter.TransactionCategoryId.HasValue)
                    queryParameters.Add("@TransactionCategoryId", filter.TransactionCategoryId);
                else
                    queryParameters.Add("@TransactionCategoryId", DBNull.Value, DbType.Int32);
                if (!String.IsNullOrEmpty(filter.Description))
                    queryParameters.Add("@Description", $"%{filter.Description}%");
                else
                    queryParameters.Add("@Description", DBNull.Value, DbType.String);

                using (var conn = Context.CreateConnection())
                {
                    return conn.Query<Transaction>(query, queryParameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Transaction GetSingle(int id)
        {
            try
            {
                var query = string.Concat("SELECT  ID, TransactionDate, Description, Amount, CategoryID, UserID, CreatedAt, ModifiedAt ",
                    " FROM  BudgetTransactions ",
                    " WHERE (@ID = ID);");
                using (var conn = Context.CreateConnection())
                {
                    return conn.QuerySingle<Transaction>(query, new { id });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save(Transaction data)
        {
            try
            {
                using (var conn = Context.CreateConnection())
                {
                    data.CreatedAt = DateTime.UtcNow;
                    return (int)conn.Insert<Transaction>(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Transaction data)
        {
            try
            {
                using (var conn = Context.CreateConnection())
                {
                    data.ModifiedAt = DateTime.UtcNow;
                    return conn.Update<Transaction>(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
