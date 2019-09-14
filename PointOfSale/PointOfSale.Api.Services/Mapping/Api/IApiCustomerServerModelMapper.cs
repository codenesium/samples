using Microsoft.AspNetCore.JsonPatch;
using PointOfSaleNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IApiCustomerServerModelMapper
	{
		ApiCustomerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCustomerServerRequestModel request);

		ApiCustomerServerRequestModel MapServerResponseToRequest(
			ApiCustomerServerResponseModel response);

		ApiCustomerClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerServerResponseModel response);

		JsonPatchDocument<ApiCustomerServerRequestModel> CreatePatch(ApiCustomerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0151d9a66cbb25020a2c7f0d75d97254</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/