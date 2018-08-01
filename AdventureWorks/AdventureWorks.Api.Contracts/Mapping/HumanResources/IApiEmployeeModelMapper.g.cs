using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiEmployeeModelMapper
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
    <Hash>d589e5b7370d7aac3e30c76f89229f0e</Hash>
</Codenesium>*/