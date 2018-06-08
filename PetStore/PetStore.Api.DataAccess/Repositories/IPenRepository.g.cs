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

                Task<List<Pen>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>de850c06a501bb254cb66ddd2f7473ea</Hash>
</Codenesium>*/