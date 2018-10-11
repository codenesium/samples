using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiVEventModelMapper
	{
		ApiVEventResponseModel MapRequestToResponse(
			int id,
			ApiVEventRequestModel request);

		ApiVEventRequestModel MapResponseToRequest(
			ApiVEventResponseModel response);

		JsonPatchDocument<ApiVEventRequestModel> CreatePatch(ApiVEventRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f96ead9c2a258e1d4636e4b828c1d90d</Hash>
</Codenesium>*/