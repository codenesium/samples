using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiLessonStatusModelMapper
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
    <Hash>57658a40f9f5ae9861f8391267283a70</Hash>
</Codenesium>*/