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
    <Hash>bcd21e0e0241357fa7c956d54d9ca029</Hash>
</Codenesium>*/