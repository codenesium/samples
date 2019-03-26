using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCultureServerModelMapper
	{
		ApiCultureServerResponseModel MapServerRequestToResponse(
			string cultureID,
			ApiCultureServerRequestModel request);

		ApiCultureServerRequestModel MapServerResponseToRequest(
			ApiCultureServerResponseModel response);

		ApiCultureClientRequestModel MapServerResponseToClientRequest(
			ApiCultureServerResponseModel response);

		JsonPatchDocument<ApiCultureServerRequestModel> CreatePatch(ApiCultureServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a30a42eeaed56452bf9ed7d3d309be72</Hash>
</Codenesium>*/