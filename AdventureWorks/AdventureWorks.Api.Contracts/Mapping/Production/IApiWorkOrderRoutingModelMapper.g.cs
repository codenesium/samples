using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiWorkOrderRoutingModelMapper
	{
		ApiWorkOrderRoutingResponseModel MapRequestToResponse(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel request);

		ApiWorkOrderRoutingRequestModel MapResponseToRequest(
			ApiWorkOrderRoutingResponseModel response);

		JsonPatchDocument<ApiWorkOrderRoutingRequestModel> CreatePatch(ApiWorkOrderRoutingRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1eda22c055dbdfc2c33884035a6fc47a</Hash>
</Codenesium>*/