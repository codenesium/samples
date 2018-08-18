using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
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
    <Hash>a2370bb1b5ff7076905e6099cc5a2637</Hash>
</Codenesium>*/