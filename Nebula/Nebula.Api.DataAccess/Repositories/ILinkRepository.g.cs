using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkRepository
        {
                Task<Link> Create(Link item);

                Task Update(Link item);

                Task Delete(int id);

                Task<Link> Get(int id);

                Task<List<Link>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<LinkLog>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);

                Task<Machine> GetMachine(int? assignedMachineId);

                Task<Chain> GetChain(int chainId);

                Task<LinkStatus> GetLinkStatus(int linkStatusId);
        }
}

/*<Codenesium>
    <Hash>275044c1c0b192fe9439d76c868eb6bf</Hash>
</Codenesium>*/