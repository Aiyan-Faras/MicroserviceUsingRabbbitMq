using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Modles;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly ILogger<BankingController> _logger;
        private readonly IAccountService _accountService;
        public BankingController(ILogger<BankingController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet("GetAccounts")]
        public ActionResult<IEnumerable<Account>> getAccounts()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost("AccountTransfer")]
        public IActionResult post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok();
        }
    }
}
