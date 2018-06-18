using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ITransactionRepository
        {
                Task<Transaction> Create(Transaction item);

                Task Update(Transaction item);

                Task Delete(int id);

                Task<Transaction> Get(int id);

                Task<List<Transaction>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Transaction>> GetTransactionStatusId(int transactionStatusId);

                Task<List<Sale>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0);

                Task<TransactionStatus> GetTransactionStatus(int transactionStatusId);
        }
}

/*<Codenesium>
    <Hash>a5ce492f62f138de94926f8844b9bc16</Hash>
</Codenesium>*/