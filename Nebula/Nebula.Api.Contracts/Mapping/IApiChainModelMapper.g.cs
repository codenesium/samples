using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiChainModelMapper
	{
		ApiChainResponseModel MapRequestToResponse(
			int id,
			ApiChainRequestModel request);

		ApiChainRequestModel MapResponseToRequest(
			ApiChainResponseModel response);

		JsonPatchDocument<ApiChainRequestModel> CreatePatch(ApiChainRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bee5baa401b5564ae4b63aa024bbca30</Hash>
</Codenesium>*/