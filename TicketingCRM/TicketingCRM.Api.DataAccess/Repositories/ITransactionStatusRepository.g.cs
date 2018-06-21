using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ITransactionStatusRepository
        {
                Task<TransactionStatus> Create(TransactionStatus item);

                Task Update(TransactionStatus item);

                Task Delete(int id);

                Task<TransactionStatus> Get(int id);

                Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Transaction>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>596289e2ea36442fcfb97609f9d3e53f</Hash>
</Codenesium>*/