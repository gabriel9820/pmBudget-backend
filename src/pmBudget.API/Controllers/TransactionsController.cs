using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pmBudget.Application.Common;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Application.Interfaces;

namespace pmBudget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsApplicationService _transactionsApplicationService;
        private readonly ILoggedInUserService _loggedInUserService;

        public TransactionsController(ITransactionsApplicationService transactionsApplicationService, ILoggedInUserService loggedInUserService)
        {
            _transactionsApplicationService = transactionsApplicationService;
            _loggedInUserService = loggedInUserService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAsync()
        {
            var transactions = await _transactionsApplicationService.FindAsync(t => t.UserId == _loggedInUserService.Id);
            var response = Response<IEnumerable<TransactionOutputModel>>.Ok(data: transactions);

            return Ok(response);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummaryAsync()
        {
            var summary = await _transactionsApplicationService.GetSummaryAsync(_loggedInUserService.Id);
            var response = Response<SummaryOutputModel>.Ok(data: summary);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var transaction = await _transactionsApplicationService.GetByIdAsync(id);
            var response = Response<TransactionOutputModel>.Ok(data: transaction);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TransactionInputModel transactionInputModel)
        {
            var createdTransaction = await _transactionsApplicationService.CreateAsync(transactionInputModel);
            var response = Response<TransactionOutputModel>.Ok(data: createdTransaction);

            return Created("", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TransactionInputModel transactionInputModel)
        {
            var updatedTransaction = await _transactionsApplicationService.UpdateAsync(id, transactionInputModel);
            var response = Response<TransactionOutputModel>.Ok(data: updatedTransaction);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _transactionsApplicationService.DeleteAsync(id);

            return NoContent();
        }
    }
}