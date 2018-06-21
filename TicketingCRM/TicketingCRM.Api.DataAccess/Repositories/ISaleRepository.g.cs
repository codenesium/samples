using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ISaleRepository
        {
                Task<Sale> Create(Sale item);

                Task Update(Sale item);

                Task Delete(int id);

                Task<Sale> Get(int id);

                Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Sale>> GetTransactionId(int transactionId);

                Task<List<SaleTickets>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0);

                Task<Transaction> GetTransaction(int transactionId);
        }
}

/*<Codenesium>
    <Hash>b00cdfb338284004e5ae4a30023ad69d</Hash>
</Codenesium>*/