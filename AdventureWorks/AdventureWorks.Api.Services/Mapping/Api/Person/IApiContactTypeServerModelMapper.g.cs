using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiContactTypeServerModelMapper
	{
		ApiContactTypeServerResponseModel MapServerRequestToResponse(
			int contactTypeID,
			ApiContactTypeServerRequestModel request);

		ApiContactTypeServerRequestModel MapServerResponseToRequest(
			ApiContactTypeServerResponseModel response);

		ApiContactTypeClientRequestModel MapServerResponseToClientRequest(
			ApiContactTypeServerResponseModel response);

		JsonPatchDocument<ApiContactTypeServerRequestModel> CreatePatch(ApiContactTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>932a5095bef70030e1a32f39d3cced94</Hash>
</Codenesium>*/