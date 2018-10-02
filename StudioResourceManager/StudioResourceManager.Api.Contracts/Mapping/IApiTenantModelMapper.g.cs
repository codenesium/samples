using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiTenantModelMapper
	{
		ApiTenantResponseModel MapRequestToResponse(
			int id,
			ApiTenantRequestModel request);

		ApiTenantRequestModel MapResponseToRequest(
			ApiTenantResponseModel response);

		JsonPatchDocument<ApiTenantRequestModel> CreatePatch(ApiTenantRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ddfa5ec27ea74142c61a737020e3215d</Hash>
</Codenesium>*/