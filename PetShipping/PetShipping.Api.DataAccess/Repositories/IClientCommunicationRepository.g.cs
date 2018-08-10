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

		Task<Client> GetClient(int clientId);

		Task<Employee> GetEmployee(int employeeId);
	}
}

/*<Codenesium>
    <Hash>7f9b81be276f07709722e4ba9dcefa63</Hash>
</Codenesium>*/