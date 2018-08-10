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
    <Hash>7aab7ebc95f5b42ba4017bf984504ccd</Hash>
</Codenesium>*/