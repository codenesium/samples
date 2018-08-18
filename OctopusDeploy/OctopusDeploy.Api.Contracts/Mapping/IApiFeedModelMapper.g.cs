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
    <Hash>c15e12ab7c37eb8185f1af6b4f43b445</Hash>
</Codenesium>*/