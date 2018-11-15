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
    <Hash>cbb272ba9c790f1602ff1d5b364dcfee</Hash>
</Codenesium>*/