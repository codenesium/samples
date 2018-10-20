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

		Task<List<LinkLog>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0);

		Task<Machine> MachineByAssignedMachineId(int? assignedMachineId);

		Task<Chain> ChainByChainId(int chainId);

		Task<LinkStatus> LinkStatusByLinkStatusId(int linkStatusId);
	}
}

/*<Codenesium>
    <Hash>c5b95d0a2c87079f6011dd57608ede7e</Hash>
</Codenesium>*/