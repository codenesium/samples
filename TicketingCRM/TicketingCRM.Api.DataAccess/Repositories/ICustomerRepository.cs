using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ICustomerRepository
	{
		Task<Customer> Create(Customer item);

		Task Update(Customer item);

		Task Delete(int id);

		Task<Customer> Get(int id);

		Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>1f7326976503e6ca4c99e02dccb553f9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/