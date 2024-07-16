using AccountTransferer.Models;
using AccountTransferer.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AccountTransferer.Controllers;

[ApiController]
public class TransferController : Controller
{
    private readonly ClientService _clientService;

    public TransferController(ClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpPost("client/{name}/{startBalance}")]
    public IActionResult Register(string name, decimal startBalance)
    {
        var client = _clientService.RegisterClient(name, startBalance);
        return Ok($"{name} was register. Your accountId is {client.Account.AccountId}");
    }

    [HttpGet("[action]")]
    public IActionResult GetAllAccounts()
    {
        var allAccounts = _clientService.GetAllAccounts();
        return Json(allAccounts.ToDictionary(x => x.AccountId, x => x.Balance));
    }
    
    [HttpPut("[action]")]
    public IActionResult Transfer([FromBody]TransferRequest request)
    {
        if (!TransferRequestValidator.IsValid(request))
            return BadRequest("Invalid request. Please, check data.");
        
        var accountFrom = _clientService.GetAccountById(request.FromAccountId);
        var accountTo = _clientService.GetAccountById(request.ToAccountId);

        if (accountFrom == null || accountTo == null)
            return BadRequest("Account doesn't open yet.");

        if (accountFrom.Balance < request.Amount)
            return BadRequest("Current balance not enough for operation.");
        
        accountFrom.Balance -= request.Amount;
        accountTo.Balance += request.Amount;
        
        return Ok("Transfer was successfully finished.");
    }
}