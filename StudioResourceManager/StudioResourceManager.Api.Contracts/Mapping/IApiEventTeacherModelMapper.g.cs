using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiEventTeacherModelMapper
	{
		ApiEventTeacherResponseModel MapRequestToResponse(
			int eventId,
			ApiEventTeacherRequestModel request);

		ApiEventTeacherRequestModel MapResponseToRequest(
			ApiEventTeacherResponseModel response);

		JsonPatchDocument<ApiEventTeacherRequestModel> CreatePatch(ApiEventTeacherRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b534906dcb39930a95897f52debe325e</Hash>
</Codenesium>*/