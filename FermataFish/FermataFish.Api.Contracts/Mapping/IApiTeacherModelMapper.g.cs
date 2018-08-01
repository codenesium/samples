using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiTeacherModelMapper
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
    <Hash>db9e9f1119d776e3f8f058fc673a9b8a</Hash>
</Codenesium>*/