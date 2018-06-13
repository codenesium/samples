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

                Task<List<Transaction>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Transaction>> GetTransactionStatusId(int transactionStatusId);

                Task<List<Sale>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d7b40e71aacd1d6a3b6cf42e9d29b315</Hash>
</Codenesium>*/