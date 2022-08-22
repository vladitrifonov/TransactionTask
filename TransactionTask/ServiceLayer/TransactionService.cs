using System.Globalization;
using TransactionTask.DataAccessLayer;

namespace TransactionTask.ServiceLayer
{
    internal class TransactionService : ITransactionService
    {
        private readonly ITransactionStorage _transactionStorage;
        public TransactionService(ITransactionStorage transactionStorage)
        {
            _transactionStorage = transactionStorage;
        }
        public async Task AddTransaction(TransactionDto transaction)
        {
            var isIdParsed = int.TryParse(transaction.Id, out var idResult);

            if (!isIdParsed)
            {
                throw new ArgumentException($"Id had wrong format. Id: {transaction.Id}");
            }

            var transactionDate = DateTime.ParseExact(transaction.TransactionDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                   
            var isAmountParsed = int.TryParse(transaction.Amount, out var amountResult);

            if (!isAmountParsed)
            {
                throw new ArgumentException($"Amount had wrong format. Amount: {transaction.Amount}");
            }

            await _transactionStorage.AddTransaction(new Transaction {Id = idResult, TransactionDate = transactionDate, Amount = amountResult });
        }

        public async Task<Transaction> GetTransaction(string id)
        {
            var isIdParsed = int.TryParse(id, out var idResult);

            if (!isIdParsed)
            {
                throw new ArgumentException($"Id had wrong format. Id: {id}");
            }

            var transation = await _transactionStorage.GetTransaction(idResult);

            if(transation == null)
            {
                throw new NullReferenceException($"There is no Transaction with this Id: {idResult}");
            }

            return transation;
        }
    }
}
