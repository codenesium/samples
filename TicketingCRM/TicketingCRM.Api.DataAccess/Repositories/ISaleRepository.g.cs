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

                Task<List<Sale>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Sale>> GetTransactionId(int transactionId);

                Task<List<SaleTickets>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d4ff0cb2c95f5677fff8899e8e34530e</Hash>
</Codenesium>*/