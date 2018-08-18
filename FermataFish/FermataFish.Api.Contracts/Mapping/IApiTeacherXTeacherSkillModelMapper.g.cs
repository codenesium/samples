using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiTeacherXTeacherSkillModelMapper
	{
		ApiTeacherXTeacherSkillResponseModel MapRequestToResponse(
			int id,
			ApiTeacherXTeacherSkillRequestModel request);

		ApiTeacherXTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherXTeacherSkillResponseModel response);

		JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> CreatePatch(ApiTeacherXTeacherSkillRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fa0e9b0a6abf6a0a7409086ed54681c6</Hash>
</Codenesium>*/