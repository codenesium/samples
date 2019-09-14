using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>fa10a1e5c4834ec9064d3e681c6226ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/