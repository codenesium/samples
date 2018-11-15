using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiTeacherSkillModelMapper
	{
		public virtual ApiTeacherSkillClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherSkillClientRequestModel request)
		{
			var response = new ApiTeacherSkillClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTeacherSkillClientRequestModel MapClientResponseToRequest(
			ApiTeacherSkillClientResponseModel response)
		{
			var request = new ApiTeacherSkillClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>8971dc2b3568311e67394e10f1e56400</Hash>
</Codenesium>*/