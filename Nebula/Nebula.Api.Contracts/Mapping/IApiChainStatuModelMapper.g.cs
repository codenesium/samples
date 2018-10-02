using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiChainStatuModelMapper
	{
		ApiChainStatuResponseModel MapRequestToResponse(
			int id,
			ApiChainStatuRequestModel request);

		ApiChainStatuRequestModel MapResponseToRequest(
			ApiChainStatuResponseModel response);

		JsonPatchDocument<ApiChainStatuRequestModel> CreatePatch(ApiChainStatuRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9c1ed5fc70565befb480a2294a5bcd75</Hash>
</Codenesium>*/