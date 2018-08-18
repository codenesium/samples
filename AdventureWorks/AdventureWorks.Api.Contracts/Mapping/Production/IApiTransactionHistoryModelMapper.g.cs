using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiTransactionHistoryModelMapper
	{
		ApiTransactionHistoryResponseModel MapRequestToResponse(
			int transactionID,
			ApiTransactionHistoryRequestModel request);

		ApiTransactionHistoryRequestModel MapResponseToRequest(
			ApiTransactionHistoryResponseModel response);

		JsonPatchDocument<ApiTransactionHistoryRequestModel> CreatePatch(ApiTransactionHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7c1798443e255fd377924f3e03613710</Hash>
</Codenesium>*/