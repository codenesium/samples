using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>225a53a5af07effeacd7c88b587c06ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/