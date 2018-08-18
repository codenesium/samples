using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiLessonStatusModelMapper
	{
		ApiLessonStatusResponseModel MapRequestToResponse(
			int id,
			ApiLessonStatusRequestModel request);

		ApiLessonStatusRequestModel MapResponseToRequest(
			ApiLessonStatusResponseModel response);

		JsonPatchDocument<ApiLessonStatusRequestModel> CreatePatch(ApiLessonStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5c82806afa193f1fc042f86a6a89ff7e</Hash>
</Codenesium>*/