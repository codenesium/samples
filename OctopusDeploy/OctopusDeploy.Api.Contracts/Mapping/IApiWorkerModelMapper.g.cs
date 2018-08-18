using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiWorkerModelMapper
	{
		ApiWorkerResponseModel MapRequestToResponse(
			string id,
			ApiWorkerRequestModel request);

		ApiWorkerRequestModel MapResponseToRequest(
			ApiWorkerResponseModel response);

		JsonPatchDocument<ApiWorkerRequestModel> CreatePatch(ApiWorkerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>402ef22756bba470dac4b2e5cc19c1c9</Hash>
</Codenesium>*/