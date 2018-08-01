using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiChainStatusModelMapper
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
    <Hash>28019021e294816152bca9e0b6387c03</Hash>
</Codenesium>*/