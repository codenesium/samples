using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiTeacherSkillModelMapper
	{
		ApiTeacherSkillResponseModel MapRequestToResponse(
			int id,
			ApiTeacherSkillRequestModel request);

		ApiTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherSkillResponseModel response);

		JsonPatchDocument<ApiTeacherSkillRequestModel> CreatePatch(ApiTeacherSkillRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ebfe6461c951df20f1e20f1aeb53233d</Hash>
</Codenesium>*/