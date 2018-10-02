using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiSysdiagramModelMapper
	{
		ApiSysdiagramResponseModel MapRequestToResponse(
			int diagramId,
			ApiSysdiagramRequestModel request);

		ApiSysdiagramRequestModel MapResponseToRequest(
			ApiSysdiagramResponseModel response);

		JsonPatchDocument<ApiSysdiagramRequestModel> CreatePatch(ApiSysdiagramRequestModel model);
	}
}

/*<Codenesium>
    <Hash>53547da7d3306be4bb0e6c8ab5ed6ae4</Hash>
</Codenesium>*/