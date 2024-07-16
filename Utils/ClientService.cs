using AccountTransferer.DataStorages;
using AccountTransferer.Models;

namespace AccountTransferer.Utils;

public class ClientService
{
    private ClientsDataStore _clientStore;
    private AccountDataStore _accountStore;

    public ClientService()
    {
        _clientStore = new ClientsDataStore();
        _accountStore = new AccountDataStore();
    }
    
    public Client RegisterClient(string name, decimal startBalance = 0)
    {
        var client = new Client(name);
        client.Account.Balance = startBalance;
        _clientStore.Add(client);
        _accountStore.Add(client.Account);

        return client;
    }

    public IReadOnlyCollection<Account> GetAllAccounts()
        => _accountStore.GetAllAccounts();

    public Client? GetClientById(Guid clientId)
        => _clientStore.GetById(clientId);

    public Account? GetAccountById(Guid accountId)
        => _accountStore.GetById(accountId);
}