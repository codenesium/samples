using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiTransactionHistoryArchiveModelMapper
	{
		ApiTransactionHistoryArchiveResponseModel MapRequestToResponse(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel request);

		ApiTransactionHistoryArchiveRequestModel MapResponseToRequest(
			ApiTransactionHistoryArchiveResponseModel response);

		JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel> CreatePatch(ApiTransactionHistoryArchiveRequestModel model);
	}
}

/*<Codenesium>
    <Hash>45a6a72838916a46cf56e581a088ab48</Hash>
</Codenesium>*/