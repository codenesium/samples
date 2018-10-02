using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiTeacherTeacherSkillModelMapper
	{
		ApiTeacherTeacherSkillResponseModel MapRequestToResponse(
			int id,
			ApiTeacherTeacherSkillRequestModel request);

		ApiTeacherTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherTeacherSkillResponseModel response);

		JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> CreatePatch(ApiTeacherTeacherSkillRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fbe52826000a31bdbd001898465f6bb1</Hash>
</Codenesium>*/