using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiChainStatusModelMapper
	{
		ApiChainStatusResponseModel MapRequestToResponse(
			int id,
			ApiChainStatusRequestModel request);

		ApiChainStatusRequestModel MapResponseToRequest(
			ApiChainStatusResponseModel response);

		JsonPatchDocument<ApiChainStatusRequestModel> CreatePatch(ApiChainStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0383ec1a5b0f22df8005329155d69975</Hash>
</Codenesium>*/