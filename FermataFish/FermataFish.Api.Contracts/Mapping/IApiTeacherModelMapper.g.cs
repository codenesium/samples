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
    <Hash>47eb369ca787092eee80aed991115d48</Hash>
</Codenesium>*/