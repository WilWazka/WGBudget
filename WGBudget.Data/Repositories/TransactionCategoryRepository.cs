using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using WGBudget.Entities.Data;
using WGBudget.Entities.Interfaces.Common;
using WGBudget.Entities.Interfaces.TransactionCategory;
using static Dapper.SqlMapper;

namespace WGBudget.Data.Repositories
{
    public class TransactionCategoryRepository : ITransactionCategoryRepository
    {

        private readonly DapperDataContext Context;
        public TransactionCategoryRepository(DapperDataContext context_)
        {
            this.Context = context_;
        }

        public bool Delete(Category data)
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

        public IEnumerable<Category> GetList(IFilter<Category> filterData)
        {
            var filter = (filterData as ISimpleFilterTransactionCategory);
            try
            {
                if (filter == null)
                    throw new ArgumentException("Filter does not implement ISimpleFilterTransactionCategory interface.", nameof(filterData));

                var query = string.Concat("SELECT  ID, Name, Description, CategoryType, UserID, CreatedAt, ModifiedAt ",
                    " FROM  TransactionCategory ",
                    " WHERE (@CategoryType IS NULL OR CategoryType = @CategoryType);",
                    " AND (@Text IS NULL OR Name LIKE @Text OR Description LIKE @Text);");

                var queryParameters = new DynamicParameters();
                if (filter.CategoryType.HasValue)
                    queryParameters.Add("@CategoryType", filter.CategoryType);
                else
                    queryParameters.Add("@CategoryType", DBNull.Value, DbType.Int32);
                if (!String.IsNullOrEmpty(filter.Text))
                    queryParameters.Add("@Text", $"%{filter.Text}%");
                else
                    queryParameters.Add("@Text", DBNull.Value, DbType.String);

                using (var conn = Context.CreateConnection())
                {
                    return conn.Query<Category>(query, queryParameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category GetSingle(int id)
        {
            try
            {
                var query = string.Concat("SELECT  ID, Name, Description, CategoryType, UserID, CreatedAt, ModifiedAt ",
                    " FROM  TransactionCategory ",
                    " WHERE (@ID = ID);");
                using (var conn = Context.CreateConnection())
                {
                    return conn.QuerySingle<Category>(query, new { id });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save(Category data)
        {
            try
            {
                using (var conn = Context.CreateConnection())
                {
                    return (int)conn.Insert<Category>(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Category data)
        {
            try
            {
                using (var conn = Context.CreateConnection())
                {
                    return conn.Update<Category>(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
