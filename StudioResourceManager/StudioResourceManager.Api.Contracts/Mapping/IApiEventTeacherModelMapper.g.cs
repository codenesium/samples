using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiEventTeacherModelMapper
	{
		ApiEventTeacherResponseModel MapRequestToResponse(
			int id,
			ApiEventTeacherRequestModel request);

		ApiEventTeacherRequestModel MapResponseToRequest(
			ApiEventTeacherResponseModel response);

		JsonPatchDocument<ApiEventTeacherRequestModel> CreatePatch(ApiEventTeacherRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8754abf2fdb45b95de691c141aad110d</Hash>
</Codenesium>*/