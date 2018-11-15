using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkService
	{
		Task<CreateResponse<ApiLinkServerResponseModel>> Create(
			ApiLinkServerRequestModel model);

		Task<UpdateResponse<ApiLinkServerResponseModel>> Update(int id,
		                                                         ApiLinkServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkServerResponseModel> Get(int id);

		Task<List<ApiLinkServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLinkServerResponseModel> ByExternalId(Guid externalId);

		Task<List<ApiLinkServerResponseModel>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkLogServerResponseModel>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bd5f9838b91986bdcd087b423c121da6</Hash>
</Codenesium>*/