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
    <Hash>b47f2fc46f3215e6d59d3087752cb4bc</Hash>
</Codenesium>*/