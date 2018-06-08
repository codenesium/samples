using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IClaspRepository
        {
                Task<Clasp> Create(Clasp item);

                Task Update(Clasp item);

                Task Delete(int id);

                Task<Clasp> Get(int id);

                Task<List<Clasp>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>281f5d89dfd50bdd64b2a249bb246e37</Hash>
</Codenesium>*/