using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.API.Models;
using VendingMachine.API.Services;

namespace VendingMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> Purchase([FromBody] Transaction transaction)
        {
            if (transaction == null || transaction.ItemId <= 0 || transaction.Amount <= 0)
            {
                return BadRequest("Invalid transaction details.");
            }

            var result = await _transactionService.ProcessTransactionAsync(transaction);
            if (result.IsSuccess)
            {
                return Ok(new { Message = "Transaction success", ChangeReturned = result.ChangeReturned });
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetTransactionHistory(DateTime fromDate, DateTime toDate)
        {
            var history = await _transactionService.GetTransactionHistoryAsync(fromDate, toDate);
            return Ok(history);
        }
    }
}