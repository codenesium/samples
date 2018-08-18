using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
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
    <Hash>812a06e12632c8d6c4afd8f8d8160af4</Hash>
</Codenesium>*/