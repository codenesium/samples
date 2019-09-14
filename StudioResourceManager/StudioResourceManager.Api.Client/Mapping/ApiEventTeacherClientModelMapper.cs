using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiEventTeacherModelMapper : IApiEventTeacherModelMapper
	{
		public virtual ApiEventTeacherClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventTeacherClientRequestModel request)
		{
			var response = new ApiEventTeacherClientResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherClientRequestModel MapClientResponseToRequest(
			ApiEventTeacherClientResponseModel response)
		{
			var request = new ApiEventTeacherClientRequestModel();
			request.SetProperties(
				response.EventId,
				response.TeacherId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4b3aee6798e412594dcc5479d0c0ace9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/