using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiRateModelMapper : IApiRateModelMapper
	{
		public virtual ApiRateClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRateClientRequestModel request)
		{
			var response = new ApiRateClientResponseModel();
			response.SetProperties(id,
			                       request.AmountPerMinute,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiRateClientRequestModel MapClientResponseToRequest(
			ApiRateClientResponseModel response)
		{
			var request = new ApiRateClientRequestModel();
			request.SetProperties(
				response.AmountPerMinute,
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>6dfc39f2bca4ed92aa0b588d48f0f65b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/