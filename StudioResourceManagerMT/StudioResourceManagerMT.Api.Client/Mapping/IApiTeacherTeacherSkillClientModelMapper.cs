using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiTeacherTeacherSkillModelMapper
	{
		ApiTeacherTeacherSkillClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherTeacherSkillClientRequestModel request);

		ApiTeacherTeacherSkillClientRequestModel MapClientResponseToRequest(
			ApiTeacherTeacherSkillClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c4d83c1c57e174b800abbfa51b133dae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/