using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IChainStatusRepository
        {
                Task<ChainStatus> Create(ChainStatus item);

                Task Update(ChainStatus item);

                Task Delete(int id);

                Task<ChainStatus> Get(int id);

                Task<List<ChainStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Chain>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a4f75eb282b0707af755dc21b88760ee</Hash>
</Codenesium>*/