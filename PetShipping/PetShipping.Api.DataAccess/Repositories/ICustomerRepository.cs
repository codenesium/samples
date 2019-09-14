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

		Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<CustomerCommunication>> CustomerCommunicationsByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e9cb1548d5cdd870ead5f05692b9adc2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/