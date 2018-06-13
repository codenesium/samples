using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IBreedRepository
        {
                Task<Breed> Create(Breed item);

                Task Update(Breed item);

                Task Delete(int id);

                Task<Breed> Get(int id);

                Task<List<Breed>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Pet>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>12f98711b800eb3a7607ecfd95c9f722</Hash>
</Codenesium>*/