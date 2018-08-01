using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiStudentModelMapper
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
    <Hash>b114759e75dd67f5f6b345e100835473</Hash>
</Codenesium>*/