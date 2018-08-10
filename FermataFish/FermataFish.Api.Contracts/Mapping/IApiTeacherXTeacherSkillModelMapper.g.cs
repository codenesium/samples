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
    <Hash>42f5fb73816d8392a3e8c26d52dd8741</Hash>
</Codenesium>*/