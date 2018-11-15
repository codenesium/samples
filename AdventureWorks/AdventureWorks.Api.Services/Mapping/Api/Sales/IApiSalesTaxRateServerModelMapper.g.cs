using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTaxRateServerModelMapper
	{
		ApiSalesTaxRateServerResponseModel MapServerRequestToResponse(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel request);

		ApiSalesTaxRateServerRequestModel MapServerResponseToRequest(
			ApiSalesTaxRateServerResponseModel response);

		ApiSalesTaxRateClientRequestModel MapServerResponseToClientRequest(
			ApiSalesTaxRateServerResponseModel response);

		JsonPatchDocument<ApiSalesTaxRateServerRequestModel> CreatePatch(ApiSalesTaxRateServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>22b8ccb2fcf1923e698bd75f3d115bc8</Hash>
</Codenesium>*/