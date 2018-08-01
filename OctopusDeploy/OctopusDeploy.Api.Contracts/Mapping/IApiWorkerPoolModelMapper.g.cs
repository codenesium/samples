using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiWorkerPoolModelMapper
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
    <Hash>a183534804d35c146b6523b8e359ee84</Hash>
</Codenesium>*/