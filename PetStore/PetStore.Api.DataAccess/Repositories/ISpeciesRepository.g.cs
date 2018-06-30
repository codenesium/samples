using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface ISpeciesRepository
        {
                Task<Species> Create(Species item);

                Task Update(Species item);

                Task Delete(int id);

                Task<Species> Get(int id);

                Task<List<Species>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Pet>> Pets(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5d363c32da74e9079eec8223a44cb657</Hash>
</Codenesium>*/