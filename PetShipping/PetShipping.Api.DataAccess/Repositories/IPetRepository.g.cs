using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>a7aed8900bbd66f179fd5df5989436b8</Hash>
</Codenesium>*/