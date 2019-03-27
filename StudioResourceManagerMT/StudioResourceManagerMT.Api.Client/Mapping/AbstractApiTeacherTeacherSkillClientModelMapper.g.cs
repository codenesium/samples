using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiTeacherTeacherSkillModelMapper
	{
		public virtual ApiTeacherTeacherSkillClientResponseModel MapClientRequestToResponse(
			int teacherId,
			ApiTeacherTeacherSkillClientRequestModel request)
		{
			var response = new ApiTeacherTeacherSkillClientResponseModel();
			response.SetProperties(teacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherTeacherSkillClientRequestModel MapClientResponseToRequest(
			ApiTeacherTeacherSkillClientResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillClientRequestModel();
			request.SetProperties(
				response.TeacherSkillId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c0884ce3a4b874cb1bb85b36dd25b39a</Hash>
</Codenesium>*/