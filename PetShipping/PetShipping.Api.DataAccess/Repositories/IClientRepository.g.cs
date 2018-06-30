using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IClientRepository
        {
                Task<Client> Create(Client item);

                Task Update(Client item);

                Task Delete(int id);

                Task<Client> Get(int id);

                Task<List<Client>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ClientCommunication>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0);

                Task<List<Pet>> Pets(int clientId, int limit = int.MaxValue, int offset = 0);

                Task<List<Sale>> Sales(int clientId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c55597e14b1129913f41bea6762c9a3b</Hash>
</Codenesium>*/