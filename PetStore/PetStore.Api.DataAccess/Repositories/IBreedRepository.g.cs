using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>a083636b819758359a3848f8bb52982c</Hash>
</Codenesium>*/