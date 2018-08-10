using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCurrencyModelMapper
	{
		ApiCurrencyResponseModel MapRequestToResponse(
			string currencyCode,
			ApiCurrencyRequestModel request);

		ApiCurrencyRequestModel MapResponseToRequest(
			ApiCurrencyResponseModel response);

		JsonPatchDocument<ApiCurrencyRequestModel> CreatePatch(ApiCurrencyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c1b986e354ff6ba7d30253ec502d5c09</Hash>
</Codenesium>*/