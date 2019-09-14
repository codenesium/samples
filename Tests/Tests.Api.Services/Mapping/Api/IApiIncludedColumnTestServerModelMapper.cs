using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiIncludedColumnTestServerModelMapper
	{
		ApiIncludedColumnTestServerResponseModel MapServerRequestToResponse(
			int id,
			ApiIncludedColumnTestServerRequestModel request);

		ApiIncludedColumnTestServerRequestModel MapServerResponseToRequest(
			ApiIncludedColumnTestServerResponseModel response);

		ApiIncludedColumnTestClientRequestModel MapServerResponseToClientRequest(
			ApiIncludedColumnTestServerResponseModel response);

		JsonPatchDocument<ApiIncludedColumnTestServerRequestModel> CreatePatch(ApiIncludedColumnTestServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>468eea0ae350d3261aef929d375697b9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/