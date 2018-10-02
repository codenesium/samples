using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiLinkTypeModelMapper
	{
		ApiLinkTypeResponseModel MapRequestToResponse(
			int id,
			ApiLinkTypeRequestModel request);

		ApiLinkTypeRequestModel MapResponseToRequest(
			ApiLinkTypeResponseModel response);

		JsonPatchDocument<ApiLinkTypeRequestModel> CreatePatch(ApiLinkTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>deee16e4365fa6a4f018f92a22bdf525</Hash>
</Codenesium>*/