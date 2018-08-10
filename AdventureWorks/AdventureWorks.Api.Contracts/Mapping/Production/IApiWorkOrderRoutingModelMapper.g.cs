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
    <Hash>26d815dc9444b8175159696971c406a1</Hash>
</Codenesium>*/