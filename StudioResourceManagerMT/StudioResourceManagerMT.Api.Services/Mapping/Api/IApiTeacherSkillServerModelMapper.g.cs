using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTeacherSkillServerModelMapper
	{
		ApiTeacherSkillServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeacherSkillServerRequestModel request);

		ApiTeacherSkillServerRequestModel MapServerResponseToRequest(
			ApiTeacherSkillServerResponseModel response);

		ApiTeacherSkillClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherSkillServerResponseModel response);

		JsonPatchDocument<ApiTeacherSkillServerRequestModel> CreatePatch(ApiTeacherSkillServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9e08373392df61c35b0d1ae60c504663</Hash>
</Codenesium>*/