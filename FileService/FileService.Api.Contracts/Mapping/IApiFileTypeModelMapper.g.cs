using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public partial interface IApiFileTypeModelMapper
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
    <Hash>fe549ccc9d9468a2ffc16200f206134f</Hash>
</Codenesium>*/