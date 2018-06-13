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

                Task<List<Clasp>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>af411227ef7b602046ceb2f4ffd41199</Hash>
</Codenesium>*/