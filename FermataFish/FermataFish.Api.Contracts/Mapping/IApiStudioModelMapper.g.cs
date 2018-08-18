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
    <Hash>568083266832928985ac348848077067</Hash>
</Codenesium>*/