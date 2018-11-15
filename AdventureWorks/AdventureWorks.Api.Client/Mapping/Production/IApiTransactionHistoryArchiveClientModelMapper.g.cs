using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiTransactionHistoryArchiveModelMapper
	{
		ApiTransactionHistoryArchiveClientResponseModel MapClientRequestToResponse(
			int transactionID,
			ApiTransactionHistoryArchiveClientRequestModel request);

		ApiTransactionHistoryArchiveClientRequestModel MapClientResponseToRequest(
			ApiTransactionHistoryArchiveClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>e70fa18a6bb0daec983bb80c0ff8c14c</Hash>
</Codenesium>*/