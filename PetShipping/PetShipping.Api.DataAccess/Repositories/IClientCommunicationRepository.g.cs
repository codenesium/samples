using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IClientCommunicationRepository
	{
		Task<ClientCommunication> Create(ClientCommunication item);

		Task Update(ClientCommunication item);

		Task Delete(int id);

		Task<ClientCommunication> Get(int id);

		Task<List<ClientCommunication>> All(int limit = int.MaxValue, int offset = 0);

		Task<Client> ClientByClientId(int clientId);

		Task<Employee> EmployeeByEmployeeId(int employeeId);
	}
}

/*<Codenesium>
    <Hash>bae5f7ec9f63479191cdde48240236d7</Hash>
</Codenesium>*/