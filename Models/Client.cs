namespace AccountTransferer.Models;

public class Client
{
    public Client(string name)
    {
        Name = name;
        ClientId = Guid.NewGuid();
        Account = new Account(ClientId);
    }
    
    public Guid ClientId { get; set; }
    
    public string Name { get; set; }
    
    public Account Account { get; set; } 
}