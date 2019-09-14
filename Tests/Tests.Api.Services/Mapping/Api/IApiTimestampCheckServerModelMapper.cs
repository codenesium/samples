using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiTimestampCheckServerModelMapper
	{
		ApiTimestampCheckServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTimestampCheckServerRequestModel request);

		ApiTimestampCheckServerRequestModel MapServerResponseToRequest(
			ApiTimestampCheckServerResponseModel response);

		ApiTimestampCheckClientRequestModel MapServerResponseToClientRequest(
			ApiTimestampCheckServerResponseModel response);

		JsonPatchDocument<ApiTimestampCheckServerRequestModel> CreatePatch(ApiTimestampCheckServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>799f8675a6a45a84e9d63686433be401</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/