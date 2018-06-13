using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface ISpeciesRepository
        {
                Task<Species> Create(Species item);

                Task Update(Species item);

                Task Delete(int id);

                Task<Species> Get(int id);

                Task<List<Species>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Pet>> Pets(int speciesId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6d66d74a074c67b56733597ca6409eb2</Hash>
</Codenesium>*/