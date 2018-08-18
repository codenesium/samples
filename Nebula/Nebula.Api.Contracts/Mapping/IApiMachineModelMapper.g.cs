using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiMachineModelMapper
	{
		ApiMachineResponseModel MapRequestToResponse(
			int id,
			ApiMachineRequestModel request);

		ApiMachineRequestModel MapResponseToRequest(
			ApiMachineResponseModel response);

		JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f8254974e25c5b9c91620e3517e51298</Hash>
</Codenesium>*/