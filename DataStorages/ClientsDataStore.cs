using AccountTransferer.Models;

namespace AccountTransferer.DataStorages;

public class ClientsDataStore
{
    private List<Client> _clients;

    public ClientsDataStore()
    {
        _clients = new List<Client>();
    }

    public void Add(Client client)
        => _clients.Add(client);

    public void Remove(Client client)
        => _clients.Remove(client);

    public Client? GetById(Guid clientId)
        => _clients.FirstOrDefault(e => e.ClientId == clientId);
}