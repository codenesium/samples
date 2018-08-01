using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPersonModelMapper
	{
		ApiPersonResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonRequestModel request);

		ApiPersonRequestModel MapResponseToRequest(
			ApiPersonResponseModel response);

		JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>caed77242e5608276807f9d026f244f9</Hash>
</Codenesium>*/