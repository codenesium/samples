using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>fded0ef0710f7a0aecf77be2e9c66678</Hash>
</Codenesium>*/