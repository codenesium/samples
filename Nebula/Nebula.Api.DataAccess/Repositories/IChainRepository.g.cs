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

                Task<List<Chain>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Clasp>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);
                Task<List<Link>> Links(int chainId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b2c52442aa2ef3e19ce94c2d6e2d525f</Hash>
</Codenesium>*/