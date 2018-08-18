using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiBillOfMaterialModelMapper
	{
		ApiBillOfMaterialResponseModel MapRequestToResponse(
			int billOfMaterialsID,
			ApiBillOfMaterialRequestModel request);

		ApiBillOfMaterialRequestModel MapResponseToRequest(
			ApiBillOfMaterialResponseModel response);

		JsonPatchDocument<ApiBillOfMaterialRequestModel> CreatePatch(ApiBillOfMaterialRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cf011fcadb3295e9af364c0eb8b56c27</Hash>
</Codenesium>*/