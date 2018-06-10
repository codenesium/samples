using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ICustomerRepository
        {
                Task<Customer> Create(Customer item);

                Task Update(Customer item);

                Task Delete(int id);

                Task<Customer> Get(int id);

                Task<List<Customer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9dad8a2e41cc967d6ef0001071e89b04</Hash>
</Codenesium>*/