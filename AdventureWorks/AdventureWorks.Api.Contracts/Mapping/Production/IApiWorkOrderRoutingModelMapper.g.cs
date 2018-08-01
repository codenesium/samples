using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiWorkOrderRoutingModelMapper
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
    <Hash>ccf586cf7f853fa156f32c4d79657d13</Hash>
</Codenesium>*/