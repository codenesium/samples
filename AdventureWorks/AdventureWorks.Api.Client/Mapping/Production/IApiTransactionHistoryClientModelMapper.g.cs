using AdventureWorksNS.Api.Contracts;
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
    <Hash>e444d127657540fd2f0b71791b9d6042</Hash>
</Codenesium>*/