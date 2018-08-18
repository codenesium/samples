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

		Task<List<ApiClaspResponseModel>> Clasps(int nextChainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkResponseModel>> Links(int chainId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ff49086747a5112d53ff4dcf938e7bf1</Hash>
</Codenesium>*/