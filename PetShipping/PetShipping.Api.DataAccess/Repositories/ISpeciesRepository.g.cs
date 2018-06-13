using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface ISpeciesRepository
        {
                Task<Species> Create(Species item);

                Task Update(Species item);

                Task Delete(int id);

                Task<Species> Get(int id);

                Task<List<Species>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Breed>> Breeds(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1bcdb3160e71d52d7661a6b6a47b81cb</Hash>
</Codenesium>*/