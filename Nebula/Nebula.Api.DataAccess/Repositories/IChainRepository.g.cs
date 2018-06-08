using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IChainRepository
        {
                Task<Chain> Create(Chain item);

                Task Update(Chain item);

                Task Delete(int id);

                Task<Chain> Get(int id);

                Task<List<Chain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>d6f547523ec9d6ffdb40c2d69621489f</Hash>
</Codenesium>*/