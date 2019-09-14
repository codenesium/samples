using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainServerModelMapper
	{
		ApiChainServerResponseModel MapServerRequestToResponse(
			int id,
			ApiChainServerRequestModel request);

		ApiChainServerRequestModel MapServerResponseToRequest(
			ApiChainServerResponseModel response);

		ApiChainClientRequestModel MapServerResponseToClientRequest(
			ApiChainServerResponseModel response);

		JsonPatchDocument<ApiChainServerRequestModel> CreatePatch(ApiChainServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>608c82f15c599adffaf2c2b4fd0b45dc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/