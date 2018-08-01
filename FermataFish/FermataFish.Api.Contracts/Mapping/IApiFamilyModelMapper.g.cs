using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiFamilyModelMapper
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
    <Hash>e7cf24beb9f08525aa0da203fc82d61a</Hash>
</Codenesium>*/