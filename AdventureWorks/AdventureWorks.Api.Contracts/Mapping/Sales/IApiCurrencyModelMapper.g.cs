using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCurrencyModelMapper
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
    <Hash>7921203872a7592e160c4a1a6a0c305a</Hash>
</Codenesium>*/