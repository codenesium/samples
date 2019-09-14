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

		Task<List<ApiLinkServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiLinkServerResponseModel> ByExternalId(Guid externalId);

		Task<List<ApiLinkServerResponseModel>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkLogServerResponseModel>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>98fdaf3824df20d1438138518e291b37</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/