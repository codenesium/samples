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
    <Hash>269654cc07e0c13ac502b0e948369dcc</Hash>
</Codenesium>*/