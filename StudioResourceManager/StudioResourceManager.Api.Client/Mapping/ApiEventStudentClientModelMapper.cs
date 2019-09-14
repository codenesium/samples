using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiEventStudentModelMapper : IApiEventStudentModelMapper
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
    <Hash>7d4d89979a1724f1ea3dc02a28366d47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/