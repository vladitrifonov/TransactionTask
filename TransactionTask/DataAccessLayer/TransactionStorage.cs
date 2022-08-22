namespace TransactionTask.DataAccessLayer
{
    internal class TransactionStorage : ITransactionStorage
    {
        private readonly List<Transaction?> _localStorage = new List<Transaction?>();

        public Task AddTransaction(Transaction transaction)
        {;
            _localStorage.Add(transaction);

            return Task.CompletedTask;
        }

        public Task<Transaction?> GetTransaction(int id)
        {
            return Task.FromResult(_localStorage.FirstOrDefault(x => x.Id == id));
        }
    }
}
