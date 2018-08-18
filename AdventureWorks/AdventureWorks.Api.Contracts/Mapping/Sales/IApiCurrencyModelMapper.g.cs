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
    <Hash>0e8a91ad827c304eac5b8bdc08749729</Hash>
</Codenesium>*/