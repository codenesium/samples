using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiEventModelMapper
	{
		ApiEventResponseModel MapRequestToResponse(
			int id,
			ApiEventRequestModel request);

		ApiEventRequestModel MapResponseToRequest(
			ApiEventResponseModel response);

		JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e2ccfd30e70129cba77edd245764a82e</Hash>
</Codenesium>*/