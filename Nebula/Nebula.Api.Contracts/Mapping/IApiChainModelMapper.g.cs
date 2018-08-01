using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiChainModelMapper
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
    <Hash>346860ecf5cca3260d6d70e764f4098d</Hash>
</Codenesium>*/