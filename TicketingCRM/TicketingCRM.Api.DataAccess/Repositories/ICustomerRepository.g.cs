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

                Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5fc4a36522deee4b05bd491bb8fef851</Hash>
</Codenesium>*/