using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiJobCandidateModelMapper
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
    <Hash>ff3b05935f9de123b77302a183076fb8</Hash>
</Codenesium>*/