using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>838a2f5b9db55a7819cb1212ff3555fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/