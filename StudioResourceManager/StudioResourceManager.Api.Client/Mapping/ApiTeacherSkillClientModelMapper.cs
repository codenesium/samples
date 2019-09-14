using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiTeacherSkillModelMapper : IApiTeacherSkillModelMapper
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
    <Hash>745cca75e6049e03606bed27372b3f3e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/