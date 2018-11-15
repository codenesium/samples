using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>c80e90b3ccf6482ae024ad8a84c823b7</Hash>
</Codenesium>*/