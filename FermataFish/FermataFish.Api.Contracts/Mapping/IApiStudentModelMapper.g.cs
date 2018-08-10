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
    <Hash>2233c2d15a68927db047e9477709a509</Hash>
</Codenesium>*/