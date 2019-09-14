using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Client
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
    <Hash>88facbc588b79f9712a1ff122860cf34</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/