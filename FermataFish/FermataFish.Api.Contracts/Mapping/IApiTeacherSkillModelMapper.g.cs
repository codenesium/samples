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
    <Hash>9fb743bd5f57ce721da65b28a106e55a</Hash>
</Codenesium>*/