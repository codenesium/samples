using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiWorkOrderModelMapper
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
    <Hash>296fdfa45fd92e288e90379fe1f15cf1</Hash>
</Codenesium>*/