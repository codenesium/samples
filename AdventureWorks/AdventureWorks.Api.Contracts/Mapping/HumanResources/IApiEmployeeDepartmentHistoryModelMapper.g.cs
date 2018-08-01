using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiEmployeeDepartmentHistoryModelMapper
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
    <Hash>cb231e5a94bbdbe22ef1340e21045552</Hash>
</Codenesium>*/