using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public interface IPenRepository
        {
                Task<Pen> Create(Pen item);

                Task Update(Pen item);

                Task Delete(int id);

                Task<Pen> Get(int id);

                Task<List<Pen>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Pet>> Pets(int penId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7325b45be5496cf2d8efd5b1bfc49c23</Hash>
</Codenesium>*/