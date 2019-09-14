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
			int id,
			ApiTeacherTeacherSkillServerRequestModel request);

		ApiTeacherTeacherSkillServerRequestModel MapServerResponseToRequest(
			ApiTeacherTeacherSkillServerResponseModel response);

		ApiTeacherTeacherSkillClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherTeacherSkillServerResponseModel response);

		JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> CreatePatch(ApiTeacherTeacherSkillServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>00d5060e4b8010b778fc5d32c78afd09</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/