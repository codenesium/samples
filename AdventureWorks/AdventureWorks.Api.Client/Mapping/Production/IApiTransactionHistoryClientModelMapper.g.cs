using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiTransactionHistoryModelMapper
	{
		ApiTransactionHistoryClientResponseModel MapClientRequestToResponse(
			int transactionID,
			ApiTransactionHistoryClientRequestModel request);

		ApiTransactionHistoryClientRequestModel MapClientResponseToRequest(
			ApiTransactionHistoryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>dd3e25806246e0336d03cd14e2fad78b</Hash>
</Codenesium>*/