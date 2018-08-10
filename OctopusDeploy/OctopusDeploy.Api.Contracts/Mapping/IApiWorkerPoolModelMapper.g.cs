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
    <Hash>cd54c8496ddb1c961b51493ee783657e</Hash>
</Codenesium>*/