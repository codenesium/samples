using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCreditCardModelMapper
	{
		ApiCreditCardClientResponseModel MapClientRequestToResponse(
			int creditCardID,
			ApiCreditCardClientRequestModel request);

		ApiCreditCardClientRequestModel MapClientResponseToRequest(
			ApiCreditCardClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ed11b38982c77e9e4f297972d25fc045</Hash>
</Codenesium>*/