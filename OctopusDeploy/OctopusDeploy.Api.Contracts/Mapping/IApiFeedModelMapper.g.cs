using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiFeedModelMapper
	{
		ApiFeedResponseModel MapRequestToResponse(
			string id,
			ApiFeedRequestModel request);

		ApiFeedRequestModel MapResponseToRequest(
			ApiFeedResponseModel response);

		JsonPatchDocument<ApiFeedRequestModel> CreatePatch(ApiFeedRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a88fcf12509b6ec23efa6d7982882694</Hash>
</Codenesium>*/