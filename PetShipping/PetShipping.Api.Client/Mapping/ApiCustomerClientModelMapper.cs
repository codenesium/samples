using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiCustomerModelMapper : IApiCustomerModelMapper
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
			                       request.Notes,
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
				response.Notes,
				response.Phone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>83b9da8fa4c6502f59ff68fd79c1f83b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/