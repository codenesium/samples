using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiWorkerTaskLeaseModelMapper
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
    <Hash>1375bc27b89cd5016d1bde1c8596af12</Hash>
</Codenesium>*/