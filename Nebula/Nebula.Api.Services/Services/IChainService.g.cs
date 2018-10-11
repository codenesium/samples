using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IChainService
	{
		Task<CreateResponse<ApiChainResponseModel>> Create(
			ApiChainRequestModel model);

		Task<UpdateResponse<ApiChainResponseModel>> Update(int id,
		                                                    ApiChainRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiChainResponseModel> Get(int id);

		Task<List<ApiChainResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiChainResponseModel> ByExternalId(Guid externalId);

		Task<List<ApiLinkResponseModel>> Links(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiChainResponseModel>> ByNextChainId(int nextChainId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7166381e3b5e9f1a66e0a83607f98ab0</Hash>
</Codenesium>*/