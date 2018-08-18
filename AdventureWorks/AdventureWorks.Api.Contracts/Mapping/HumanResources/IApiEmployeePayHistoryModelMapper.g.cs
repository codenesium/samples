using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiEmployeePayHistoryModelMapper
	{
		ApiEmployeePayHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel request);

		ApiEmployeePayHistoryRequestModel MapResponseToRequest(
			ApiEmployeePayHistoryResponseModel response);

		JsonPatchDocument<ApiEmployeePayHistoryRequestModel> CreatePatch(ApiEmployeePayHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>858123b03a6a4c0314ca51d8e74d0714</Hash>
</Codenesium>*/