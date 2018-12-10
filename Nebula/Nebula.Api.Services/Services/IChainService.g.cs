using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IChainService
	{
		Task<CreateResponse<ApiChainServerResponseModel>> Create(
			ApiChainServerRequestModel model);

		Task<UpdateResponse<ApiChainServerResponseModel>> Update(int id,
		                                                          ApiChainServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainServerResponseModel> Get(int id);

		Task<List<ApiChainServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiChainServerResponseModel> ByExternalId(Guid externalId);

		Task<List<ApiClaspServerResponseModel>> ClaspsByNextChainId(int nextChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiClaspServerResponseModel>> ClaspsByPreviousChainId(int previousChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkServerResponseModel>> LinksByChainId(int chainId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>56be1968751201c20ab82f5c6d6ffdf1</Hash>
</Codenesium>*/