using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiRateModelMapper
	{
		ApiRateResponseModel MapRequestToResponse(
			int id,
			ApiRateRequestModel request);

		ApiRateRequestModel MapResponseToRequest(
			ApiRateResponseModel response);

		JsonPatchDocument<ApiRateRequestModel> CreatePatch(ApiRateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>adcf67f31583aaf3e831f1b38f27a4eb</Hash>
</Codenesium>*/