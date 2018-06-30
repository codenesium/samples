using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>51b4a883749cd9673f30090021ce688b</Hash>
</Codenesium>*/