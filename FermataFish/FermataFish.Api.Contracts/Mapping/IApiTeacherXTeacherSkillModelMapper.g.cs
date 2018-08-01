using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiTeacherXTeacherSkillModelMapper
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
    <Hash>0b2ecf55714e1c12e9adf1892c451039</Hash>
</Codenesium>*/