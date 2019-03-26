using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCustomerServerModelMapper
	{
		ApiCustomerServerResponseModel MapServerRequestToResponse(
			int customerID,
			ApiCustomerServerRequestModel request);

		ApiCustomerServerRequestModel MapServerResponseToRequest(
			ApiCustomerServerResponseModel response);

		ApiCustomerClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerServerResponseModel response);

		JsonPatchDocument<ApiCustomerServerRequestModel> CreatePatch(ApiCustomerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>de9955f356b0b02c1328f34202b173c7</Hash>
</Codenesium>*/