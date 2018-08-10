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
    <Hash>24289058cde9c9fec62dad4e1b4ea1a7</Hash>
</Codenesium>*/