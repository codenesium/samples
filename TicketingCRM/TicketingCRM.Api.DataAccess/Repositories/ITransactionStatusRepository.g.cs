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

                Task<List<TransactionStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>0c52c9caebddd48095a045a3a1ba0e6b</Hash>
</Codenesium>*/