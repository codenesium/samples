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

                Task<List<ChainStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>761e4f80168d75877d1140dbf13724f6</Hash>
</Codenesium>*/