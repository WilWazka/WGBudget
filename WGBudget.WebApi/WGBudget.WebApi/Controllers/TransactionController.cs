using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using WGBudget.Entities.Messages.Transaction;
using WGBudget.Services;

namespace WGBudget.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        #region Fields
        private readonly ITransactionService transactionService;
        #endregion

        public TransactionController(ITransactionService transactionSvc)
        {
            transactionService = transactionSvc;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> Get([FromBody] TransactionListRequest request)
        {
            try
            {
                //request.UserId = User.Identity.Id;
                var result = await transactionService.GetTransactionsAsync(request);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> Get(int id)
        {
            try
            {
                //request.UserId = User.Identity.Id;
                var result = await transactionService.GetTransactionByIdAsync(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TransactionCreateRequest request)
        {
            try
            {
                //request.UserId = User.Identity.Id;
                var result = await transactionService.CreateTransactionAsync(request);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionDto>> Put(int id, [FromBody] TransactionUpdateRequest request)
        {
            try
            {
                //request.UserId = User.Identity.Id;
                var result = await transactionService.UpdateTransactionAsync(request);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await transactionService.DeleteTransactionAsync(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
