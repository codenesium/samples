using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>e3ac4a7b1d6de13cf00260bfe88b4a09</Hash>
</Codenesium>*/