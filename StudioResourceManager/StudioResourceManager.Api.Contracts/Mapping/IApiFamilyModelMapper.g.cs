using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiFamilyModelMapper
	{
		ApiFamilyResponseModel MapRequestToResponse(
			int id,
			ApiFamilyRequestModel request);

		ApiFamilyRequestModel MapResponseToRequest(
			ApiFamilyResponseModel response);

		JsonPatchDocument<ApiFamilyRequestModel> CreatePatch(ApiFamilyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e18dbab59df6b5079dc237a39b5b207f</Hash>
</Codenesium>*/