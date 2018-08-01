using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiTransactionHistoryArchiveModelMapper
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
    <Hash>9a65fd788c6c78ce1aa8946cc49a26a1</Hash>
</Codenesium>*/