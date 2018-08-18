using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiWorkerTaskLeaseModelMapper
	{
		ApiWorkerTaskLeaseResponseModel MapRequestToResponse(
			string id,
			ApiWorkerTaskLeaseRequestModel request);

		ApiWorkerTaskLeaseRequestModel MapResponseToRequest(
			ApiWorkerTaskLeaseResponseModel response);

		JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> CreatePatch(ApiWorkerTaskLeaseRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d2a7e0df47f2387a603295ed196d51e0</Hash>
</Codenesium>*/