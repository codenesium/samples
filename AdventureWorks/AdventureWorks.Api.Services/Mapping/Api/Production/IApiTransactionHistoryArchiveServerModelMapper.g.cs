using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiTransactionHistoryArchiveServerModelMapper
	{
		ApiTransactionHistoryArchiveServerResponseModel MapServerRequestToResponse(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel request);

		ApiTransactionHistoryArchiveServerRequestModel MapServerResponseToRequest(
			ApiTransactionHistoryArchiveServerResponseModel response);

		ApiTransactionHistoryArchiveClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionHistoryArchiveServerResponseModel response);

		JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel> CreatePatch(ApiTransactionHistoryArchiveServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e7a1311a08d0f4d118abed4c5697a23a</Hash>
</Codenesium>*/