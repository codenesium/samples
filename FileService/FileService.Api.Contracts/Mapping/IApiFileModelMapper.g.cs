using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public partial interface IApiFileModelMapper
	{
		ApiFileResponseModel MapRequestToResponse(
			int id,
			ApiFileRequestModel request);

		ApiFileRequestModel MapResponseToRequest(
			ApiFileResponseModel response);

		JsonPatchDocument<ApiFileRequestModel> CreatePatch(ApiFileRequestModel model);
	}
}

/*<Codenesium>
    <Hash>250af5ba6d6ab1427285039b1a107003</Hash>
</Codenesium>*/