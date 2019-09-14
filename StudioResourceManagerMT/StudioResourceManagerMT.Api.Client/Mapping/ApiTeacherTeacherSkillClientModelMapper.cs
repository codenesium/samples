using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiTeacherTeacherSkillModelMapper : IApiTeacherTeacherSkillModelMapper
	{
		public virtual ApiTeacherTeacherSkillClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherTeacherSkillClientRequestModel request)
		{
			var response = new ApiTeacherTeacherSkillClientResponseModel();
			response.SetProperties(id,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherTeacherSkillClientRequestModel MapClientResponseToRequest(
			ApiTeacherTeacherSkillClientResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillClientRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>990f51e2094e876ea9a2e68e6b767c90</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/