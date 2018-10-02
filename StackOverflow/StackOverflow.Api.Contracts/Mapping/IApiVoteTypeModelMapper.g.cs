using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiVoteTypeModelMapper
	{
		ApiVoteTypeResponseModel MapRequestToResponse(
			int id,
			ApiVoteTypeRequestModel request);

		ApiVoteTypeRequestModel MapResponseToRequest(
			ApiVoteTypeResponseModel response);

		JsonPatchDocument<ApiVoteTypeRequestModel> CreatePatch(ApiVoteTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c38b0ebf4cae02d0cc70bc724e673cd8</Hash>
</Codenesium>*/