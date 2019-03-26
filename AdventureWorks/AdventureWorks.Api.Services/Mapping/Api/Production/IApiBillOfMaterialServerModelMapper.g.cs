using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBillOfMaterialServerModelMapper
	{
		ApiBillOfMaterialServerResponseModel MapServerRequestToResponse(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel request);

		ApiBillOfMaterialServerRequestModel MapServerResponseToRequest(
			ApiBillOfMaterialServerResponseModel response);

		ApiBillOfMaterialClientRequestModel MapServerResponseToClientRequest(
			ApiBillOfMaterialServerResponseModel response);

		JsonPatchDocument<ApiBillOfMaterialServerRequestModel> CreatePatch(ApiBillOfMaterialServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8851e62dd0da7d16695690b193420990</Hash>
</Codenesium>*/