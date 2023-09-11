using WGBudget.Data.Repositories;
using WGBudget.Services;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "ITransactionRepository constructor test")]
        public void TransactionRepository_does_not_accept_null_argument()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => { ITransactionRepository repository = new TransactionRepository(null); });
        }

        [Test(Description = "ITransactionService constructor test")]
        public void TransactionService_does_not_accept_null_argument()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => { ITransactionService service = new TransactionService(null); });
        }
    }
}