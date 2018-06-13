using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>c74786c86f8f58b13cf38009b84487ec</Hash>
</Codenesium>*/