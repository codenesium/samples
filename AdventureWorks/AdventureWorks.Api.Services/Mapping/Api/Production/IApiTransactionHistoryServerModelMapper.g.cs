using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiTransactionHistoryServerModelMapper
	{
		ApiTransactionHistoryServerResponseModel MapServerRequestToResponse(
			int transactionID,
			ApiTransactionHistoryServerRequestModel request);

		ApiTransactionHistoryServerRequestModel MapServerResponseToRequest(
			ApiTransactionHistoryServerResponseModel response);

		ApiTransactionHistoryClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionHistoryServerResponseModel response);

		JsonPatchDocument<ApiTransactionHistoryServerRequestModel> CreatePatch(ApiTransactionHistoryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>17f4975d7bfcef8a5291cbf98291257b</Hash>
</Codenesium>*/