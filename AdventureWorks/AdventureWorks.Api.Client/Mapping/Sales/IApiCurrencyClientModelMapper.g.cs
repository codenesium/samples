using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCurrencyModelMapper
	{
		ApiCurrencyClientResponseModel MapClientRequestToResponse(
			string currencyCode,
			ApiCurrencyClientRequestModel request);

		ApiCurrencyClientRequestModel MapClientResponseToRequest(
			ApiCurrencyClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c1014133ea49d8ca5ac78b8077181099</Hash>
</Codenesium>*/