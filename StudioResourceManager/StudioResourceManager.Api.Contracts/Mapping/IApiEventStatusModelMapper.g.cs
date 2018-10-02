using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiEventStatusModelMapper
	{
		ApiEventStatusResponseModel MapRequestToResponse(
			int id,
			ApiEventStatusRequestModel request);

		ApiEventStatusRequestModel MapResponseToRequest(
			ApiEventStatusResponseModel response);

		JsonPatchDocument<ApiEventStatusRequestModel> CreatePatch(ApiEventStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>79d5629629a902aab4a0d1d06126d8db</Hash>
</Codenesium>*/