using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTeacherTeacherSkillServerModelMapper
	{
		ApiTeacherTeacherSkillServerResponseModel MapServerRequestToResponse(
			int teacherId,
			ApiTeacherTeacherSkillServerRequestModel request);

		ApiTeacherTeacherSkillServerRequestModel MapServerResponseToRequest(
			ApiTeacherTeacherSkillServerResponseModel response);

		ApiTeacherTeacherSkillClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherTeacherSkillServerResponseModel response);

		JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> CreatePatch(ApiTeacherTeacherSkillServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3ff392af36f2b4075ad90cebbf811417</Hash>
</Codenesium>*/