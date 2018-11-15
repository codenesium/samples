using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityServerModelMapper
	{
		ApiBusinessEntityServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel request);

		ApiBusinessEntityServerRequestModel MapServerResponseToRequest(
			ApiBusinessEntityServerResponseModel response);

		ApiBusinessEntityClientRequestModel MapServerResponseToClientRequest(
			ApiBusinessEntityServerResponseModel response);

		JsonPatchDocument<ApiBusinessEntityServerRequestModel> CreatePatch(ApiBusinessEntityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bf1df1eae4d01fda27dc286e039a828f</Hash>
</Codenesium>*/