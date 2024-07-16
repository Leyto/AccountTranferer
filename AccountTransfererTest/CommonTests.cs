using AccountTransferer.Models;
using AccountTransferer.Utils;
using NUnit.Framework;

namespace AccountTransfererTest;

[TestFixture]
public class CommonTests
{
    [Test]
    public void TransferRequestValidatorTest()
    {
        Assert.AreEqual(false, TransferRequestValidator.IsValid(null));
        Assert.AreEqual(false, 
            TransferRequestValidator.IsValid(new TransferRequest { Amount = 0, FromAccountId = Guid.NewGuid(), ToAccountId = Guid.NewGuid()}));
    }

    [Test]
    public void ClientServiceRegistrationTest()
    {
        var clientService = new ClientService();
        clientService.RegisterClient("first client");
        Assert.AreEqual(1, clientService.GetAllAccounts().Count);
        
        var firstClient = clientService.GetAllAccounts().FirstOrDefault();
        Assert.AreNotEqual(null, firstClient);
        Assert.AreEqual(0, firstClient.Balance);
        
        clientService.RegisterClient("second client");
        Assert.AreEqual(2, clientService.GetAllAccounts().Count);
    }
}