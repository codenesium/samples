using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiTagServerModelMapper
	{
		ApiTagServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTagServerRequestModel request);

		ApiTagServerRequestModel MapServerResponseToRequest(
			ApiTagServerResponseModel response);

		ApiTagClientRequestModel MapServerResponseToClientRequest(
			ApiTagServerResponseModel response);

		JsonPatchDocument<ApiTagServerRequestModel> CreatePatch(ApiTagServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c1437ea324fcdf65b3df18a3c730aacf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/