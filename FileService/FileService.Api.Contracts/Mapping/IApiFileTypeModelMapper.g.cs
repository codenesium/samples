using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public interface IApiFileTypeModelMapper
	{
		ApiFileTypeResponseModel MapRequestToResponse(
			int id,
			ApiFileTypeRequestModel request);

		ApiFileTypeRequestModel MapResponseToRequest(
			ApiFileTypeResponseModel response);

		JsonPatchDocument<ApiFileTypeRequestModel> CreatePatch(ApiFileTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f589a74005ee8c29349a373d2866c7b8</Hash>
</Codenesium>*/