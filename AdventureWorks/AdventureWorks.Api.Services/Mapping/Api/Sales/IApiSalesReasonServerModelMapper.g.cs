using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesReasonServerModelMapper
	{
		ApiSalesReasonServerResponseModel MapServerRequestToResponse(
			int salesReasonID,
			ApiSalesReasonServerRequestModel request);

		ApiSalesReasonServerRequestModel MapServerResponseToRequest(
			ApiSalesReasonServerResponseModel response);

		ApiSalesReasonClientRequestModel MapServerResponseToClientRequest(
			ApiSalesReasonServerResponseModel response);

		JsonPatchDocument<ApiSalesReasonServerRequestModel> CreatePatch(ApiSalesReasonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>662c90885dc5d673d0f7e5e90a2ce4a7</Hash>
</Codenesium>*/