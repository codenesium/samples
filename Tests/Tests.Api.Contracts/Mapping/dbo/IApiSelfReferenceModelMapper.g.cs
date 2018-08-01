using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiSelfReferenceModelMapper
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
    <Hash>88cac2e701ee88b2f1cc117b5a96486b</Hash>
</Codenesium>*/