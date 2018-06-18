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

                Task<List<Clasp>> All(int limit = int.MaxValue, int offset = 0);

                Task<Chain> GetChain(int nextChainId);
        }
}

/*<Codenesium>
    <Hash>38a6e291f06c19227c01ef8579aacf00</Hash>
</Codenesium>*/