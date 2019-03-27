using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiEventTeacherModelMapper
	{
		public virtual ApiEventTeacherClientResponseModel MapClientRequestToResponse(
			int eventId,
			ApiEventTeacherClientRequestModel request)
		{
			var response = new ApiEventTeacherClientResponseModel();
			response.SetProperties(eventId,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherClientRequestModel MapClientResponseToRequest(
			ApiEventTeacherClientResponseModel response)
		{
			var request = new ApiEventTeacherClientRequestModel();
			request.SetProperties(
				response.TeacherId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>e80a58d875d476f89ac61af5368f1a01</Hash>
</Codenesium>*/