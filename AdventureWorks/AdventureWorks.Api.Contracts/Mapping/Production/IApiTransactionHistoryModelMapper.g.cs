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
    <Hash>58947936a54dd5d36101f349c72ecae4</Hash>
</Codenesium>*/