using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiCustomerModelMapper
	{
		public virtual ApiCustomerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCustomerClientRequestModel request)
		{
			var response = new ApiCustomerClientResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone);
			return response;
		}

		public virtual ApiCustomerClientRequestModel MapClientResponseToRequest(
			ApiCustomerClientResponseModel response)
		{
			var request = new ApiCustomerClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0cb91ff3bb5d6937d24d6322bdb63976</Hash>
</Codenesium>*/