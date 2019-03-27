using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiCustomerCommunicationModelMapper
	{
		public virtual ApiCustomerCommunicationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCustomerCommunicationClientRequestModel request)
		{
			var response = new ApiCustomerCommunicationClientResponseModel();
			response.SetProperties(id,
			                       request.CustomerId,
			                       request.DateCreated,
			                       request.EmployeeId,
			                       request.Notes);
			return response;
		}

		public virtual ApiCustomerCommunicationClientRequestModel MapClientResponseToRequest(
			ApiCustomerCommunicationClientResponseModel response)
		{
			var request = new ApiCustomerCommunicationClientRequestModel();
			request.SetProperties(
				response.CustomerId,
				response.DateCreated,
				response.EmployeeId,
				response.Notes);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5c7884a0cf008081b7f395be261e269f</Hash>
</Codenesium>*/