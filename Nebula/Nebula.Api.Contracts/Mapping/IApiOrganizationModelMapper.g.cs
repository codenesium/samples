using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiOrganizationModelMapper
	{
		ApiOrganizationResponseModel MapRequestToResponse(
			int id,
			ApiOrganizationRequestModel request);

		ApiOrganizationRequestModel MapResponseToRequest(
			ApiOrganizationResponseModel response);

		JsonPatchDocument<ApiOrganizationRequestModel> CreatePatch(ApiOrganizationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5177adf0731aa48c5b7487bebb42aae2</Hash>
</Codenesium>*/