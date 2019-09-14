using Microsoft.AspNetCore.JsonPatch;
using PointOfSaleNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IApiSaleServerModelMapper
	{
		ApiSaleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleServerRequestModel request);

		ApiSaleServerRequestModel MapServerResponseToRequest(
			ApiSaleServerResponseModel response);

		ApiSaleClientRequestModel MapServerResponseToClientRequest(
			ApiSaleServerResponseModel response);

		JsonPatchDocument<ApiSaleServerRequestModel> CreatePatch(ApiSaleServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d3cde62794de34e252d0d90f07160482</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/