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

		Task<Machine> MachineByAssignedMachineId(int? assignedMachineId);

		Task<Chain> ChainByChainId(int chainId);

		Task<LinkStatus> LinkStatusByLinkStatusId(int linkStatusId);
	}
}

/*<Codenesium>
    <Hash>c2254ba101ca96cac12c76d87d9c4997</Hash>
</Codenesium>*/