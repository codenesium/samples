using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiTeacherModelMapper
	{
		ApiTeacherResponseModel MapRequestToResponse(
			int id,
			ApiTeacherRequestModel request);

		ApiTeacherRequestModel MapResponseToRequest(
			ApiTeacherResponseModel response);

		JsonPatchDocument<ApiTeacherRequestModel> CreatePatch(ApiTeacherRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2d6083db08e9ae0cb99e37f52aae4d5d</Hash>
</Codenesium>*/