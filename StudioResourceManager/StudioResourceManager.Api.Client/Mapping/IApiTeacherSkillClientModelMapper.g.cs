using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>41b56de46795c57627bdd8ed072d4301</Hash>
</Codenesium>*/