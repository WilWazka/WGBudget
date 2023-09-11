using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WGBudget.Data
{
    public class DapperDataContext
    {
        public const string WorkingConnectionName = "SqlConnection";
        public const string DataMasterConnectionName = "MasterConnection";

        #region Constructor 
        private readonly IConfiguration _configuration;

        public DapperDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion Constructor 

        public IDbConnection CreateConnection()
                => new SqlConnection(_configuration.GetConnectionString(DapperDataContext.WorkingConnectionName));
        public IDbConnection CreateMasterConnection()
                => new SqlConnection(_configuration.GetConnectionString(DapperDataContext.DataMasterConnectionName));
    }
}
