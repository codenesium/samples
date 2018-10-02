using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiStudentModelMapper
	{
		ApiStudentResponseModel MapRequestToResponse(
			int id,
			ApiStudentRequestModel request);

		ApiStudentRequestModel MapResponseToRequest(
			ApiStudentResponseModel response);

		JsonPatchDocument<ApiStudentRequestModel> CreatePatch(ApiStudentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d0aa4d9951f04d278b84c61d3e351b95</Hash>
</Codenesium>*/