using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>6d6b0a06b3714db1bc26ab51b8776053</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/