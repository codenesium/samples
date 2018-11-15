using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ITeamService
	{
		Task<CreateResponse<ApiTeamServerResponseModel>> Create(
			ApiTeamServerRequestModel model);

		Task<UpdateResponse<ApiTeamServerResponseModel>> Update(int id,
		                                                         ApiTeamServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeamServerResponseModel> Get(int id);

		Task<List<ApiTeamServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiTeamServerResponseModel> ByName(string name);

		Task<List<ApiTeamServerResponseModel>> ByChainStatusId(int teamId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>33c8a3b50ad7922a0d89778eee49601b</Hash>
</Codenesium>*/