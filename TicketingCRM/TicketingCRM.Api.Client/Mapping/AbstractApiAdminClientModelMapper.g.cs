using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiAdminModelMapper
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
    <Hash>7d24cf5fdd5cd294fb3739d0cb379c07</Hash>
</Codenesium>*/