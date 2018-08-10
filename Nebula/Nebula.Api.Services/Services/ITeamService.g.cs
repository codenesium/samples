using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ITeamService
	{
		Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model);

		Task<UpdateResponse<ApiTeamResponseModel>> Update(int id,
		                                                   ApiTeamRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeamResponseModel> Get(int id);

		Task<List<ApiTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiChainResponseModel>> Chains(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMachineRefTeamResponseModel>> MachineRefTeams(int teamId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e10819526d8738679d12c8427bd3b137</Hash>
</Codenesium>*/