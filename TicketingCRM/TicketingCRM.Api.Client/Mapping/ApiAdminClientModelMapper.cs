using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiAdminModelMapper : IApiAdminModelMapper
	{
		public virtual ApiAdminClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAdminClientRequestModel request)
		{
			var response = new ApiAdminClientResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Password,
			                       request.Phone,
			                       request.Username);
			return response;
		}

		public virtual ApiAdminClientRequestModel MapClientResponseToRequest(
			ApiAdminClientResponseModel response)
		{
			var request = new ApiAdminClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Password,
				response.Phone,
				response.Username);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>da8c615fba754293ed44ede300f8423b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/