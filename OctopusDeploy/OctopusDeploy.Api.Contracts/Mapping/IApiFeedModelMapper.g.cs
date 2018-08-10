using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiFeedModelMapper
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
    <Hash>055cc58b4a3195848b1bab12de7d9806</Hash>
</Codenesium>*/