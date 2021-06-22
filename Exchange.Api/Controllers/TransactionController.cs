using Exchange.Api.Models;
using Exchange.Business.Interfaces;
using Exchange.Business.Models;
using Exchange.Domain.DTOs;
using Exchange.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Exchange.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ExchangeController
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService,
            ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpPost()]
        [Route("buy")]
        [ProducesResponseType(typeof(ApiResponse<TransactionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Buy(int userId, decimal baseCurrencyAmout, CurrencyTypeEnum currencyType)
        {
            try
            {
                Result<TransactionDto> result = await _transactionService.BuyAsync(userId, baseCurrencyAmout, currencyType);

                return Respond(result);                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TransactionController::Buy");
                throw;
            }
        }
    }
}
