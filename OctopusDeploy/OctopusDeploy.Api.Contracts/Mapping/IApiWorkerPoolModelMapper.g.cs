using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiWorkerPoolModelMapper
	{
		ApiWorkerPoolResponseModel MapRequestToResponse(
			string id,
			ApiWorkerPoolRequestModel request);

		ApiWorkerPoolRequestModel MapResponseToRequest(
			ApiWorkerPoolResponseModel response);

		JsonPatchDocument<ApiWorkerPoolRequestModel> CreatePatch(ApiWorkerPoolRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5fb1e3bd515a8d87f97e66d8f19ec3bd</Hash>
</Codenesium>*/