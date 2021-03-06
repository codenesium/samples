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

		Task<List<Link>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Link> ByExternalId(Guid externalId);

		Task<List<Link>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<List<LinkLog>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0);

		Task<Machine> MachineByAssignedMachineId(int? assignedMachineId);

		Task<Chain> ChainByChainId(int chainId);

		Task<LinkStatus> LinkStatusByLinkStatusId(int linkStatusId);
	}
}

/*<Codenesium>
    <Hash>4e3d0fbddbfd1292f26ed2545de94049</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/