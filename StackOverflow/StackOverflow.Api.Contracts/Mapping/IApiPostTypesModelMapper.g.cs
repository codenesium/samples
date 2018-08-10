using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostTypesModelMapper
	{
		ApiPostTypesResponseModel MapRequestToResponse(
			int id,
			ApiPostTypesRequestModel request);

		ApiPostTypesRequestModel MapResponseToRequest(
			ApiPostTypesResponseModel response);

		JsonPatchDocument<ApiPostTypesRequestModel> CreatePatch(ApiPostTypesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b65bad43a487d0ed0d2d283412e85bda</Hash>
</Codenesium>*/