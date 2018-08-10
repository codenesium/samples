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
    <Hash>1313fd9922c757b8239187d549fdfcd8</Hash>
</Codenesium>*/