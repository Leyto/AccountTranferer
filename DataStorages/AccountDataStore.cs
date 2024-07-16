using AccountTransferer.Models;

namespace AccountTransferer.DataStorages;

public class AccountDataStore
{
    private List<Account> _accouts;
    
    public AccountDataStore()
    {
        _accouts = new List<Account>();
    }
    
    public void Add(Account account)
        => _accouts.Add(account);

    public void Remove(Account account)
        => _accouts.Remove(account);

    public IReadOnlyCollection<Account> GetAllAccounts()
        => _accouts.AsReadOnly();

    public Account? GetById(Guid accountId)
        => _accouts.FirstOrDefault(e => e.AccountId == accountId);
}