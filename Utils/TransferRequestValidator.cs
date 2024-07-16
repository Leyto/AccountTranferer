using AccountTransferer.Models;

namespace AccountTransferer.Utils;

public static class TransferRequestValidator
{
    public static bool IsValid(TransferRequest? request)
    {
        return request != null && request.Amount != 0;
    }
}