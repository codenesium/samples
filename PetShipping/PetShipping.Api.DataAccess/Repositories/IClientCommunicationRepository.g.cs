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

                Task<List<ClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>dc6f6f34d6634d6a7bd91aa328607c82</Hash>
</Codenesium>*/