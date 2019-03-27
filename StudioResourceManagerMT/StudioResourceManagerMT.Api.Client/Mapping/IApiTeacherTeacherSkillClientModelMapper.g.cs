using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiTeacherTeacherSkillModelMapper
	{
		ApiTeacherTeacherSkillClientResponseModel MapClientRequestToResponse(
			int teacherId,
			ApiTeacherTeacherSkillClientRequestModel request);

		ApiTeacherTeacherSkillClientRequestModel MapClientResponseToRequest(
			ApiTeacherTeacherSkillClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>9522e6aa21ecb6384b8c62da0d9bfa85</Hash>
</Codenesium>*/