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

                Task<List<Transaction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Transaction>> GetTransactionStatusId(int transactionStatusId);
        }
}

/*<Codenesium>
    <Hash>f0445ad8639ec5c414747ad502c5b664</Hash>
</Codenesium>*/