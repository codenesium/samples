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

                Task<List<Customer>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>215177d87dd0c06b933f2282faeff88c</Hash>
</Codenesium>*/