using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiJobCandidateServerModelMapper
	{
		ApiJobCandidateServerResponseModel MapServerRequestToResponse(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel request);

		ApiJobCandidateServerRequestModel MapServerResponseToRequest(
			ApiJobCandidateServerResponseModel response);

		ApiJobCandidateClientRequestModel MapServerResponseToClientRequest(
			ApiJobCandidateServerResponseModel response);

		JsonPatchDocument<ApiJobCandidateServerRequestModel> CreatePatch(ApiJobCandidateServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>30e219d02feed2f58dfdee4b8b3e464f</Hash>
</Codenesium>*/