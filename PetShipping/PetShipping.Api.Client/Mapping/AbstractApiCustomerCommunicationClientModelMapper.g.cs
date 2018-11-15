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
			                       request.Note);
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
				response.Note);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>aa568d914d42399ed13219f33f40c239</Hash>
</Codenesium>*/