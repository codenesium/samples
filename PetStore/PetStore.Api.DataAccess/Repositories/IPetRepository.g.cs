using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
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
                Task<Pen> GetPen(int penId);
                Task<Species> GetSpecies(int speciesId);
        }
}

/*<Codenesium>
    <Hash>f5c43cb7f162da4c637210d7194a142c</Hash>
</Codenesium>*/