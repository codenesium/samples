using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface ICustomerRepository
	{
		Task<Customer> Create(Customer item);

		Task Update(Customer item);

		Task Delete(int id);

		Task<Customer> Get(int id);

		Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<CustomerCommunication>> CustomerCommunicationsByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9dfc9f72942b92cdbc8eb59423f567c4</Hash>
</Codenesium>*/