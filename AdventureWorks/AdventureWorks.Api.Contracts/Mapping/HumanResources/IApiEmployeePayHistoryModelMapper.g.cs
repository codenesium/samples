using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiEmployeePayHistoryModelMapper
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
    <Hash>17114c76b9c7d33d5761c9777a594d05</Hash>
</Codenesium>*/