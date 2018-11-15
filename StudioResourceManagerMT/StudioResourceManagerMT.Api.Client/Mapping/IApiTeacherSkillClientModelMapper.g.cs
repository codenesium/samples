using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiTeacherSkillModelMapper
	{
		ApiTeacherSkillClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherSkillClientRequestModel request);

		ApiTeacherSkillClientRequestModel MapClientResponseToRequest(
			ApiTeacherSkillClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>82f19318f30a8bb8fe3bb0a2fb595d13</Hash>
</Codenesium>*/