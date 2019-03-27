using Microsoft.AspNetCore.JsonPatch;
using PointOfSaleNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IApiProductServerModelMapper
	{
		ApiProductServerResponseModel MapServerRequestToResponse(
			int id,
			ApiProductServerRequestModel request);

		ApiProductServerRequestModel MapServerResponseToRequest(
			ApiProductServerResponseModel response);

		ApiProductClientRequestModel MapServerResponseToClientRequest(
			ApiProductServerResponseModel response);

		JsonPatchDocument<ApiProductServerRequestModel> CreatePatch(ApiProductServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b504c4a0b8bb111f676ec890758879b4</Hash>
</Codenesium>*/