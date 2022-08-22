namespace TransactionTask.ServiceLayer
{
    internal interface ITransactionService
    {
        Task AddTransaction(TransactionDto transaction);
        Task<Transaction> GetTransaction(string id);
    }
}
