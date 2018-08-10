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
    <Hash>5d2378c7fb4603f82c8d614c03047c75</Hash>
</Codenesium>*/