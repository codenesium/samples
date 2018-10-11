using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiTeacherTeacherSkillModelMapper
	{
		ApiTeacherTeacherSkillResponseModel MapRequestToResponse(
			int teacherId,
			ApiTeacherTeacherSkillRequestModel request);

		ApiTeacherTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherTeacherSkillResponseModel response);

		JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> CreatePatch(ApiTeacherTeacherSkillRequestModel model);
	}
}

/*<Codenesium>
    <Hash>912fc6921d2a605840d0e9d8018751d3</Hash>
</Codenesium>*/