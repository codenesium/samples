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

                Task<List<ChainStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Chain>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d1a5edb1a4d5407ac62f72f28891a301</Hash>
</Codenesium>*/