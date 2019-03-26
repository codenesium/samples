using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesPersonServerModelMapper
	{
		ApiSalesPersonServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiSalesPersonServerRequestModel request);

		ApiSalesPersonServerRequestModel MapServerResponseToRequest(
			ApiSalesPersonServerResponseModel response);

		ApiSalesPersonClientRequestModel MapServerResponseToClientRequest(
			ApiSalesPersonServerResponseModel response);

		JsonPatchDocument<ApiSalesPersonServerRequestModel> CreatePatch(ApiSalesPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>41f52a41b41f2f330885920e6eab7213</Hash>
</Codenesium>*/