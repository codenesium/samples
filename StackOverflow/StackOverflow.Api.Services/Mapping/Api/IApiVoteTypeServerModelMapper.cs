using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteTypeServerModelMapper
	{
		ApiVoteTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVoteTypeServerRequestModel request);

		ApiVoteTypeServerRequestModel MapServerResponseToRequest(
			ApiVoteTypeServerResponseModel response);

		ApiVoteTypeClientRequestModel MapServerResponseToClientRequest(
			ApiVoteTypeServerResponseModel response);

		JsonPatchDocument<ApiVoteTypeServerRequestModel> CreatePatch(ApiVoteTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b7b14f02e3e3547b1628a12b18c0c134</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/