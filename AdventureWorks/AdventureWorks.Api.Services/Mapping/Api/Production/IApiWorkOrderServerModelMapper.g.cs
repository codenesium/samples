using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiWorkOrderServerModelMapper
	{
		ApiWorkOrderServerResponseModel MapServerRequestToResponse(
			int workOrderID,
			ApiWorkOrderServerRequestModel request);

		ApiWorkOrderServerRequestModel MapServerResponseToRequest(
			ApiWorkOrderServerResponseModel response);

		ApiWorkOrderClientRequestModel MapServerResponseToClientRequest(
			ApiWorkOrderServerResponseModel response);

		JsonPatchDocument<ApiWorkOrderServerRequestModel> CreatePatch(ApiWorkOrderServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>465815711194fc6eed3b260f09c10ca2</Hash>
</Codenesium>*/