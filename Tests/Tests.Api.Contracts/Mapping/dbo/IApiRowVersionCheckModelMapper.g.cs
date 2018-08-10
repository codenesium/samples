using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiRowVersionCheckModelMapper
	{
		ApiRowVersionCheckResponseModel MapRequestToResponse(
			int id,
			ApiRowVersionCheckRequestModel request);

		ApiRowVersionCheckRequestModel MapResponseToRequest(
			ApiRowVersionCheckResponseModel response);

		JsonPatchDocument<ApiRowVersionCheckRequestModel> CreatePatch(ApiRowVersionCheckRequestModel model);
	}
}

/*<Codenesium>
    <Hash>05d0c921b7e231cfabdb6f0472ab3b83</Hash>
</Codenesium>*/