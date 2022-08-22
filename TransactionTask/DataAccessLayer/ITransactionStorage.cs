namespace TransactionTask.DataAccessLayer
{
    internal interface ITransactionStorage
    {
        Task AddTransaction(Transaction transaction);
        Task<Transaction?> GetTransaction(int id);
    }
}
