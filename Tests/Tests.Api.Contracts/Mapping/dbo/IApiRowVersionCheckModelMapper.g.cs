using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiRowVersionCheckModelMapper
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
    <Hash>301efc6df220a14b3d099100148347df</Hash>
</Codenesium>*/