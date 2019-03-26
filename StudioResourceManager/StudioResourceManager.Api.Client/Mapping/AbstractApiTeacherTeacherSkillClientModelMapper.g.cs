using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiTeacherTeacherSkillModelMapper
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
    <Hash>ea76e03cbe2c3234d64954b1fdc17972</Hash>
</Codenesium>*/