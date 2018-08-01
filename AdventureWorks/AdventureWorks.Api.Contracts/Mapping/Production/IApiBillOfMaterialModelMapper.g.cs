using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiBillOfMaterialModelMapper
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
    <Hash>d1563265bfccd35855c8eded17f0edbb</Hash>
</Codenesium>*/