using AdventureWorksNS.Api.Contracts;
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
    <Hash>ef617e9fa986f13285a773de7b60f836</Hash>
</Codenesium>*/