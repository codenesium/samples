using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface IBreedRepository
        {
                Task<Breed> Create(Breed item);

                Task Update(Breed item);

                Task Delete(int id);

                Task<Breed> Get(int id);

                Task<List<Breed>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Pet>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4ef216f5c8e3f4bef5d35693cbb16d58</Hash>
</Codenesium>*/