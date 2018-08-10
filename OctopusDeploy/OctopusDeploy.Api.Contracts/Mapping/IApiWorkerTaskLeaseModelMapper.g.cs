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
    <Hash>9e913db28670269b0019812266ba735e</Hash>
</Codenesium>*/