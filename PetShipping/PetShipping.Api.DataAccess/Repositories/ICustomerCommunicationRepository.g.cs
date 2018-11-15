using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface ICustomerCommunicationRepository
	{
		Task<CustomerCommunication> Create(CustomerCommunication item);

		Task Update(CustomerCommunication item);

		Task Delete(int id);

		Task<CustomerCommunication> Get(int id);

		Task<List<CustomerCommunication>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<CustomerCommunication>> ByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);

		Task<List<CustomerCommunication>> ByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<Customer> CustomerByCustomerId(int customerId);

		Task<Employee> EmployeeByEmployeeId(int employeeId);
	}
}

/*<Codenesium>
    <Hash>2ed39c6ea17b9cf74bf69ac4d09d5e9c</Hash>
</Codenesium>*/