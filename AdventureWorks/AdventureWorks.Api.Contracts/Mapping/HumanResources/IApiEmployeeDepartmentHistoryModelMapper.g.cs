using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiEmployeeDepartmentHistoryModelMapper
	{
		ApiEmployeeDepartmentHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel request);

		ApiEmployeeDepartmentHistoryRequestModel MapResponseToRequest(
			ApiEmployeeDepartmentHistoryResponseModel response);

		JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel> CreatePatch(ApiEmployeeDepartmentHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b95a6d848ec3cd4389c7c89cc2acc14a</Hash>
</Codenesium>*/