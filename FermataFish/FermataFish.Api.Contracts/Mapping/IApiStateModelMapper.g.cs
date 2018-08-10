using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiStateModelMapper
	{
		ApiStateResponseModel MapRequestToResponse(
			int id,
			ApiStateRequestModel request);

		ApiStateRequestModel MapResponseToRequest(
			ApiStateResponseModel response);

		JsonPatchDocument<ApiStateRequestModel> CreatePatch(ApiStateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b20feb08a0e45e6646dd1647bf35143c</Hash>
</Codenesium>*/