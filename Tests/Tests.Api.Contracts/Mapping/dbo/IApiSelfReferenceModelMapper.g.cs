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
    <Hash>59150ac102f23565472838a9baf6cdd2</Hash>
</Codenesium>*/