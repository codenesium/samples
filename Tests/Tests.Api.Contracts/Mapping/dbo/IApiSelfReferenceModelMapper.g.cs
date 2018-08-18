using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiSelfReferenceModelMapper
	{
		ApiSelfReferenceResponseModel MapRequestToResponse(
			int id,
			ApiSelfReferenceRequestModel request);

		ApiSelfReferenceRequestModel MapResponseToRequest(
			ApiSelfReferenceResponseModel response);

		JsonPatchDocument<ApiSelfReferenceRequestModel> CreatePatch(ApiSelfReferenceRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a8d2923e25dfd898f21c06c049df510b</Hash>
</Codenesium>*/