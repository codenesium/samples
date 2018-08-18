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
    <Hash>0eb920e68e57aedcc442d50d04cb95f2</Hash>
</Codenesium>*/