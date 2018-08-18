using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiWorkOrderModelMapper
	{
		ApiWorkOrderResponseModel MapRequestToResponse(
			int workOrderID,
			ApiWorkOrderRequestModel request);

		ApiWorkOrderRequestModel MapResponseToRequest(
			ApiWorkOrderResponseModel response);

		JsonPatchDocument<ApiWorkOrderRequestModel> CreatePatch(ApiWorkOrderRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b18760733c57179911597f45968f44e7</Hash>
</Codenesium>*/