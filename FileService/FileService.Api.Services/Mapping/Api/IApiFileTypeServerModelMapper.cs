using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileTypeServerModelMapper
	{
		ApiFileTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFileTypeServerRequestModel request);

		ApiFileTypeServerRequestModel MapServerResponseToRequest(
			ApiFileTypeServerResponseModel response);

		ApiFileTypeClientRequestModel MapServerResponseToClientRequest(
			ApiFileTypeServerResponseModel response);

		JsonPatchDocument<ApiFileTypeServerRequestModel> CreatePatch(ApiFileTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>52f50419e63f338d9cbb69293f5ea2b5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/