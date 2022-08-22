using TransactionTask;
using TransactionTask.DataAccessLayer;
using TransactionTask.ServiceLayer;

await Run();

async Task Run()
{
    ITransactionStorage transactionStorage = new TransactionStorage();

    ITransactionService transactionService = new TransactionService(transactionStorage);

    Console.WriteLine("You have 3 commands: \nadd: Adding transaction \nget: Getting transaction \nexit: Exit from application \n");
   
    while(true)
    {
        Console.WriteLine("Write command \n");
        var input = Console.ReadLine();
        try
        {
            if (input == "exit")
            {
                return;
            }
            else if (input == "add")
            {
                Console.WriteLine("Write Id:");
                var id = Console.ReadLine();
                Console.WriteLine("Write TransactionDate:");
                var transactionDate = Console.ReadLine();
                Console.WriteLine("Write Amount:");
                var amount = Console.ReadLine();
                await transactionService.AddTransaction(new TransactionDto { Id = id, TransactionDate = transactionDate, Amount = amount });
                Console.WriteLine("You added transaction");
            }
            else if (input == "get")
            {
                Console.WriteLine("Write Id:");
                var id = Console.ReadLine();
                var transaction = await transactionService.GetTransaction(id);
                Console.WriteLine($"You recieved transaction: {transaction}");
            }
            else
            {
                Console.WriteLine("You typed wrong command");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }        
    }   
}