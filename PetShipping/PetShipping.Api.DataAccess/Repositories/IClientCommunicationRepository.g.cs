using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
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
    <Hash>091b1933119fd0110bce75d03d26c73b</Hash>
</Codenesium>*/