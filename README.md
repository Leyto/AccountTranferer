Just simple application for initation money transfer between different accounts.

1. Solution structure.
   In main folder there is two project:
     - main webAPI application with all utility services,
     - project with test om main services. 
2. How to build
   This is simple dotnet appliaction with no problem to build and start.
3. How to use
   a. Start application.
   b. At first yoou need to resister clients. Use POST-method `~/client/{name}/{startBalance}` where name – client's name, startBalance – balance on start for new client (0 by default). After registration you will reciew succes-message with your accountID.
   с. If you need to check all existing account – use GET-method `~/GetAllAccounts`. In answer you will recies list of AccountIDs with current balance.
   d. To transfer money between two account you need to use PUT-method `~/Transfer`. In body you need send json in format:
    {
      "fromAccountId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "toAccountId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "amount": 0
    }.
   
   e. To check application state you can send GET-method `~/Health`. If all good you will recieve Success-message with text 'Healthy'.
5. In solution you can find Folder AccountTransfererTest with unit-tests.
    
