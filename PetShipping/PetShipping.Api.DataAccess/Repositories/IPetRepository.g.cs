using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPetRepository
        {
                Task<Pet> Create(Pet item);

                Task Update(Pet item);

                Task Delete(int id);

                Task<Pet> Get(int id);

                Task<List<Pet>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Sale>> Sales(int petId, int limit = int.MaxValue, int offset = 0);

                Task<Breed> GetBreed(int breedId);
                Task<Client> GetClient(int clientId);
        }
}

/*<Codenesium>
    <Hash>332ede67a0dd20609e2a0a38ad1a2245</Hash>
</Codenesium>*/