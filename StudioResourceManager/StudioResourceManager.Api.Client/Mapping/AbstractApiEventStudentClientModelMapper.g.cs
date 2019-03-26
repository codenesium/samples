using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiEventStudentModelMapper
	{
		public virtual ApiEventStudentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStudentClientRequestModel request)
		{
			var response = new ApiEventStudentClientResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentClientRequestModel MapClientResponseToRequest(
			ApiEventStudentClientResponseModel response)
		{
			var request = new ApiEventStudentClientRequestModel();
			request.SetProperties(
				response.EventId,
				response.StudentId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>174c5fd18f32aa854e01fb148f7e8f7e</Hash>
</Codenesium>*/