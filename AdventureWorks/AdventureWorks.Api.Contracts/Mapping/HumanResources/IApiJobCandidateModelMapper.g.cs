using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiJobCandidateModelMapper
	{
		ApiJobCandidateResponseModel MapRequestToResponse(
			int jobCandidateID,
			ApiJobCandidateRequestModel request);

		ApiJobCandidateRequestModel MapResponseToRequest(
			ApiJobCandidateResponseModel response);

		JsonPatchDocument<ApiJobCandidateRequestModel> CreatePatch(ApiJobCandidateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9b6f04610b27cf78e3b118e4389000ad</Hash>
</Codenesium>*/