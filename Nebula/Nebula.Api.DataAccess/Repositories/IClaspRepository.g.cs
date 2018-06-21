using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IClaspRepository
        {
                Task<Clasp> Create(Clasp item);

                Task Update(Clasp item);

                Task Delete(int id);

                Task<Clasp> Get(int id);

                Task<List<Clasp>> All(int limit = int.MaxValue, int offset = 0);

                Task<Chain> GetChain(int nextChainId);
        }
}

/*<Codenesium>
    <Hash>8215a83aecc245308ecc6fe609f08168</Hash>
</Codenesium>*/