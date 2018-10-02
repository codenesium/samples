using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiEventStudentModelMapper
	{
		ApiEventStudentResponseModel MapRequestToResponse(
			int id,
			ApiEventStudentRequestModel request);

		ApiEventStudentRequestModel MapResponseToRequest(
			ApiEventStudentResponseModel response);

		JsonPatchDocument<ApiEventStudentRequestModel> CreatePatch(ApiEventStudentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>49738993c962dc5f7a453b334cdab18b</Hash>
</Codenesium>*/