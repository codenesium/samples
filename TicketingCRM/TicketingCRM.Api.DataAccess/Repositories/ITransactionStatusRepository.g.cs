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

                Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Transaction>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>da145603c51abfd817cec78be9588846</Hash>
</Codenesium>*/