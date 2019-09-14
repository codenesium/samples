using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>cb43ca5b2bd31faa2cd969a53ceda5e4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/