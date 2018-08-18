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
    <Hash>7b4f052363f3507d2c3fccdde30351cb</Hash>
</Codenesium>*/