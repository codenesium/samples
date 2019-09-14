using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
    <Hash>5a73bdf4f0e6ba34fcea41976fa490fb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/