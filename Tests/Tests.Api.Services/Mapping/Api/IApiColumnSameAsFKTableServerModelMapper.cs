using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiColumnSameAsFKTableServerModelMapper
	{
		ApiColumnSameAsFKTableServerResponseModel MapServerRequestToResponse(
			int id,
			ApiColumnSameAsFKTableServerRequestModel request);

		ApiColumnSameAsFKTableServerRequestModel MapServerResponseToRequest(
			ApiColumnSameAsFKTableServerResponseModel response);

		ApiColumnSameAsFKTableClientRequestModel MapServerResponseToClientRequest(
			ApiColumnSameAsFKTableServerResponseModel response);

		JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel> CreatePatch(ApiColumnSameAsFKTableServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0316fd9a83df65f170dc70fdbe5a8214</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/