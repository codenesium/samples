using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface IPenRepository
        {
                Task<Pen> Create(Pen item);

                Task Update(Pen item);

                Task Delete(int id);

                Task<Pen> Get(int id);

                Task<List<Pen>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Pet>> Pets(int penId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0fe8e604fcfe89050fb41eca7b3b2bb4</Hash>
</Codenesium>*/