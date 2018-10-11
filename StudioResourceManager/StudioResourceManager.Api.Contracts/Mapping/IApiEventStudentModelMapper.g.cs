using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiEventStudentModelMapper
	{
		ApiEventStudentResponseModel MapRequestToResponse(
			int eventId,
			ApiEventStudentRequestModel request);

		ApiEventStudentRequestModel MapResponseToRequest(
			ApiEventStudentResponseModel response);

		JsonPatchDocument<ApiEventStudentRequestModel> CreatePatch(ApiEventStudentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f16ace8dfc19f95fadf49869612dacf2</Hash>
</Codenesium>*/