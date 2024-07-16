namespace AccountTransferer.Models;

public class Account
{
    public Account(Guid clientId)
    {
        AccountId = Guid.NewGuid();
        ClientId = clientId;
        Balance = 0;
        // TODO Client? Добавить инициализацию после того, как разберусь с датасторами 
    }
    
    public Guid AccountId { get; set; }
    
    public decimal Balance { get; set; }
    
    public Guid ClientId { get; set; }
    
    public virtual Client Client { get; set; }
}