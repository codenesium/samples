using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiTeacherSkillModelMapper
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
    <Hash>0b0d3c1d3d93d10d4e1b01f6de96f026</Hash>
</Codenesium>*/