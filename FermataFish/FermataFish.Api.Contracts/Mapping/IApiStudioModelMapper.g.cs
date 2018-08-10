using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiStudioModelMapper
	{
		ApiStudioResponseModel MapRequestToResponse(
			int id,
			ApiStudioRequestModel request);

		ApiStudioRequestModel MapResponseToRequest(
			ApiStudioResponseModel response);

		JsonPatchDocument<ApiStudioRequestModel> CreatePatch(ApiStudioRequestModel model);
	}
}

/*<Codenesium>
    <Hash>07ff7df5bc3bfc6b333985f78c043e26</Hash>
</Codenesium>*/