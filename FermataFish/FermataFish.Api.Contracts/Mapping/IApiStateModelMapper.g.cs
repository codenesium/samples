using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiStateModelMapper
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
    <Hash>e77dad1fbe2326919d3e6b280d4598a2</Hash>
</Codenesium>*/