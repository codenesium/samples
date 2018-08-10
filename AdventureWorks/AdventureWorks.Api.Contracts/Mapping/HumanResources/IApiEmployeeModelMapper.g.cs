using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiEmployeeModelMapper
	{
		ApiEmployeeResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmployeeRequestModel request);

		ApiEmployeeRequestModel MapResponseToRequest(
			ApiEmployeeResponseModel response);

		JsonPatchDocument<ApiEmployeeRequestModel> CreatePatch(ApiEmployeeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>209f21c99223823d27b7608babc86f0a</Hash>
</Codenesium>*/