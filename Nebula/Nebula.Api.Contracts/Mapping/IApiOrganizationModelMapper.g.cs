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
    <Hash>aacf13a2b671159c1919382f3e13486c</Hash>
</Codenesium>*/