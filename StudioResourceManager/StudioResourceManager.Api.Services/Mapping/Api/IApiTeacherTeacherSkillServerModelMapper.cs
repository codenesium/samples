using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>b6ba179499c953a2d26b0532942d86b6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/