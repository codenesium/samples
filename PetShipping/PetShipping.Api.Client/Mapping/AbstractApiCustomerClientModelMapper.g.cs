using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
			                       request.Note,
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
				response.Note,
				response.Phone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>72597fdc7cde5418a1837ef5364cc034</Hash>
</Codenesium>*/