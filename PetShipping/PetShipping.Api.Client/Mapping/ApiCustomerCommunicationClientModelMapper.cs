using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiCustomerCommunicationModelMapper : IApiCustomerCommunicationModelMapper
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
    <Hash>1d048fdeb475bee2299b27586f2316a8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/