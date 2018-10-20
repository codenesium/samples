using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkService
	{
		Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model);

		Task<UpdateResponse<ApiLinkResponseModel>> Update(int id,
		                                                   ApiLinkRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkResponseModel> Get(int id);

		Task<List<ApiLinkResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLinkResponseModel> ByExternalId(Guid externalId);

		Task<List<ApiLinkResponseModel>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkLogResponseModel>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5929784777627e226ff9b50a825a900e</Hash>
</Codenesium>*/