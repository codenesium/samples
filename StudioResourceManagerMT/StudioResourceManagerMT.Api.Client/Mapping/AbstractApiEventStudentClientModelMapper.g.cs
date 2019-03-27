using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiEventStudentModelMapper
	{
		public virtual ApiEventStudentClientResponseModel MapClientRequestToResponse(
			int eventId,
			ApiEventStudentClientRequestModel request)
		{
			var response = new ApiEventStudentClientResponseModel();
			response.SetProperties(eventId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentClientRequestModel MapClientResponseToRequest(
			ApiEventStudentClientResponseModel response)
		{
			var request = new ApiEventStudentClientRequestModel();
			request.SetProperties(
				response.StudentId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b2e546df7f1a0ded6dd3eb991773c53b</Hash>
</Codenesium>*/