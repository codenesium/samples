using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ITransactionStatusRepository
        {
                Task<TransactionStatus> Create(TransactionStatus item);

                Task Update(TransactionStatus item);

                Task Delete(int id);

                Task<TransactionStatus> Get(int id);

                Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Transaction>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6822db3b8b36ee5adbbeda53dc6cc314</Hash>
</Codenesium>*/