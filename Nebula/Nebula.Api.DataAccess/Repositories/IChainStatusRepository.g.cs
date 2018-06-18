using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>5e00ce74fa3cb1ca3394b427a8d25094</Hash>
</Codenesium>*/