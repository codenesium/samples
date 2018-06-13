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

                Task<List<ClientCommunication>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>807433fafd1e2bbacc771cbfb8720494</Hash>
</Codenesium>*/