using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface ILinkRepository
	{
		Task<Link> Create(Link item);

		Task Update(Link item);

		Task Delete(int id);

		Task<Link> Get(int id);

		Task<List<Link>> All(int limit = int.MaxValue, int offset = 0);

		Task<Link> ByExternalId(Guid externalId);

		Task<List<Link>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<List<LinkLog>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);

		Task<Machine> GetMachine(int? assignedMachineId);

		Task<Chain> GetChain(int chainId);

		Task<LinkStatu> GetLinkStatu(int linkStatusId);
	}
}

/*<Codenesium>
    <Hash>7cffa07fc80370d9d4a83ff4bc055322</Hash>
</Codenesium>*/