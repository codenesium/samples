using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
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
    <Hash>cc52f454fb5c501d01568dce07896f95</Hash>
</Codenesium>*/