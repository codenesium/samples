using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiWorkerModelMapper
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
    <Hash>64d52313ff1bd0395cfe9817ce0fa1c5</Hash>
</Codenesium>*/