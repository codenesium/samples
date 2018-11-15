using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiClientCommunicationModelMapper
	{
		public virtual ApiClientCommunicationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClientCommunicationClientRequestModel request)
		{
			var response = new ApiClientCommunicationClientResponseModel();
			response.SetProperties(id,
			                       request.ClientId,
			                       request.DateCreated,
			                       request.EmployeeId,
			                       request.Note);
			return response;
		}

		public virtual ApiClientCommunicationClientRequestModel MapClientResponseToRequest(
			ApiClientCommunicationClientResponseModel response)
		{
			var request = new ApiClientCommunicationClientRequestModel();
			request.SetProperties(
				response.ClientId,
				response.DateCreated,
				response.EmployeeId,
				response.Note);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d4d439ba6f4e1a967724e2a8ee39e88f</Hash>
</Codenesium>*/