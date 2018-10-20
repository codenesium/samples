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

		Task<ApiTeamResponseModel> ByName(string name);

		Task<List<ApiChainResponseModel>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeamResponseModel>> ByMachineId(int teamId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c42a17d0f0413988027d4606ee7f76ab</Hash>
</Codenesium>*/