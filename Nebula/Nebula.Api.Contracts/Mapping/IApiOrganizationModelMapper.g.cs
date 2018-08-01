using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiOrganizationModelMapper
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
    <Hash>f592562548312b8855316eb3cea8dc8c</Hash>
</Codenesium>*/