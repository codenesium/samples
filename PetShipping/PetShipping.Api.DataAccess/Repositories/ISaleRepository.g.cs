using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface ISaleRepository
        {
                Task<Sale> Create(Sale item);

                Task Update(Sale item);

                Task Delete(int id);

                Task<Sale> Get(int id);

                Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0);

                Task<Client> GetClient(int clientId);

                Task<Pet> GetPet(int petId);
        }
}

/*<Codenesium>
    <Hash>c2fd828b80b4442d3f35a990932d8217</Hash>
</Codenesium>*/