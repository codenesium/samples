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

		Task<List<CustomerCommunication>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<CustomerCommunication>> ByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);

		Task<List<CustomerCommunication>> ByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<Customer> CustomerByCustomerId(int customerId);

		Task<Employee> EmployeeByEmployeeId(int employeeId);
	}
}

/*<Codenesium>
    <Hash>b0677fd79f883914be33ad01b7527513</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/