using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IChainStatusService
	{
		Task<CreateResponse<ApiChainStatusServerResponseModel>> Create(
			ApiChainStatusServerRequestModel model);

		Task<UpdateResponse<ApiChainStatusServerResponseModel>> Update(int id,
		                                                                ApiChainStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainStatusServerResponseModel> Get(int id);

		Task<List<ApiChainStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiChainStatusServerResponseModel> ByName(string name);

		Task<List<ApiChainStatusServerResponseModel>> ByTeamId(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1fe925665fd28165fd0e76b169a7e259</Hash>
</Codenesium>*/