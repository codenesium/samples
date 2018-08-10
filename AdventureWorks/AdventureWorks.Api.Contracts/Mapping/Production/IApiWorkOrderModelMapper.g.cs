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
    <Hash>93081d80f28b8fedcbaff5336b174c0f</Hash>
</Codenesium>*/