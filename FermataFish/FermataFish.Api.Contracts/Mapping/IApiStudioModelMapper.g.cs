using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiStudioModelMapper
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
    <Hash>e9f739735f7bdd81ce14f2133a0915a9</Hash>
</Codenesium>*/