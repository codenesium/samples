using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiUnitServerModelMapper
	{
		ApiUnitServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUnitServerRequestModel request);

		ApiUnitServerRequestModel MapServerResponseToRequest(
			ApiUnitServerResponseModel response);

		ApiUnitClientRequestModel MapServerResponseToClientRequest(
			ApiUnitServerResponseModel response);

		JsonPatchDocument<ApiUnitServerRequestModel> CreatePatch(ApiUnitServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>330b4def8f0e45592c1458d334d3f334</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/