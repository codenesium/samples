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
    <Hash>6b9550b9f9afbd4bd783f55fa07182fa</Hash>
</Codenesium>*/