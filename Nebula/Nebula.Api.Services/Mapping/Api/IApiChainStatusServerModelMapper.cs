using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainStatusServerModelMapper
	{
		ApiChainStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiChainStatusServerRequestModel request);

		ApiChainStatusServerRequestModel MapServerResponseToRequest(
			ApiChainStatusServerResponseModel response);

		ApiChainStatusClientRequestModel MapServerResponseToClientRequest(
			ApiChainStatusServerResponseModel response);

		JsonPatchDocument<ApiChainStatusServerRequestModel> CreatePatch(ApiChainStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9a57b270425843bd2b21adcd8df5ba94</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/