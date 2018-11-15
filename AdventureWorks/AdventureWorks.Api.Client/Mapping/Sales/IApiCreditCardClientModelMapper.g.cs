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
    <Hash>f5b26312eae983ae1b054d6197e03958</Hash>
</Codenesium>*/