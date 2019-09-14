using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiAdminModelMapper : IApiAdminModelMapper
	{
		public virtual ApiAdminClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAdminClientRequestModel request)
		{
			var response = new ApiAdminClientResponseModel();
			response.SetProperties(id,
			                       request.Birthday,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.UserId);
			return response;
		}

		public virtual ApiAdminClientRequestModel MapClientResponseToRequest(
			ApiAdminClientResponseModel response)
		{
			var request = new ApiAdminClientRequestModel();
			request.SetProperties(
				response.Birthday,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>e89c06de5b8230a24784b2847aa1655d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/