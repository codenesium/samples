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
    <Hash>6dec601c0ec005b91193a21efa007124</Hash>
</Codenesium>*/