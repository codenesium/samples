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
    <Hash>8eca6cf57465119b94351676e4649c7c</Hash>
</Codenesium>*/