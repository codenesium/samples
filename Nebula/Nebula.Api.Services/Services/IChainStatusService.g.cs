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

		Task<List<ApiChainStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiChainStatusServerResponseModel> ByName(string name);

		Task<List<ApiChainServerResponseModel>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>71855b0be04652992595881c18fad236</Hash>
</Codenesium>*/