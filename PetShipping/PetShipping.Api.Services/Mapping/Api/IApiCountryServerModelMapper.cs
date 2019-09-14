using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCountryServerModelMapper
	{
		ApiCountryServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCountryServerRequestModel request);

		ApiCountryServerRequestModel MapServerResponseToRequest(
			ApiCountryServerResponseModel response);

		ApiCountryClientRequestModel MapServerResponseToClientRequest(
			ApiCountryServerResponseModel response);

		JsonPatchDocument<ApiCountryServerRequestModel> CreatePatch(ApiCountryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b286521bb23625ce5477af97f4de0281</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/