using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ISaleRepository
        {
                Task<Sale> Create(Sale item);

                Task Update(Sale item);

                Task Delete(int id);

                Task<Sale> Get(int id);

                Task<List<Sale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Sale>> GetTransactionId(int transactionId);
        }
}

/*<Codenesium>
    <Hash>5ebaa6a46830a91f204e2a96bf1da8f7</Hash>
</Codenesium>*/