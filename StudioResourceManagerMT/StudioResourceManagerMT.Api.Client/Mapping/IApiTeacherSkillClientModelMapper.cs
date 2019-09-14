using StudioResourceManagerMTNS.Api.Contracts;
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
    <Hash>73f233a1615c0424be225dfbfa01f130</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/