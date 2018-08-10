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
    <Hash>2d018ecc00af11353661bdc0af5002b3</Hash>
</Codenesium>*/