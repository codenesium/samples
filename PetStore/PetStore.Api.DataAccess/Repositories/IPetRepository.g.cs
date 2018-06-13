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

                Task<List<Pet>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Sale>> Sales(int petId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e00d2e26b8b60fc2d84f42a925c76bf3</Hash>
</Codenesium>*/