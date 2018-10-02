using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
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
    <Hash>483e4a818d5a91a7b70dd6a586360b92</Hash>
</Codenesium>*/