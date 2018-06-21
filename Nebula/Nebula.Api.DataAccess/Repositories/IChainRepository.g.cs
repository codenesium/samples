using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IChainRepository
        {
                Task<Chain> Create(Chain item);

                Task Update(Chain item);

                Task Delete(int id);

                Task<Chain> Get(int id);

                Task<List<Chain>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Clasp>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);

                Task<List<Link>> Links(int chainId, int limit = int.MaxValue, int offset = 0);

                Task<ChainStatus> GetChainStatus(int chainStatusId);

                Task<Team> GetTeam(int teamId);
        }
}

/*<Codenesium>
    <Hash>c4fd1c7740d1d4dc73a40265edaca419</Hash>
</Codenesium>*/