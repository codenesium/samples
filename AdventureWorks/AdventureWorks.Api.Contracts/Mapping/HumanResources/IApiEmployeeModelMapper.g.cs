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
    <Hash>10e528716c7db89dbf2ba50f019cbffe</Hash>
</Codenesium>*/