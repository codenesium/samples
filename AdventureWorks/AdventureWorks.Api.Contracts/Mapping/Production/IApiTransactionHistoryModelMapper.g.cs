using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiTransactionHistoryModelMapper
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
    <Hash>b684840f0eb44fe6dc225529aacb2d8c</Hash>
</Codenesium>*/