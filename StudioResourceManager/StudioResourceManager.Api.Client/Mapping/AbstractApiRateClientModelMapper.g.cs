using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiRateModelMapper
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
    <Hash>7f4ed1291d27a1237b1da15b802070e3</Hash>
</Codenesium>*/