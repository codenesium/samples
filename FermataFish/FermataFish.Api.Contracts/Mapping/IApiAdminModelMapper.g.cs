using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiAdminModelMapper
	{
		ApiAdminResponseModel MapRequestToResponse(
			int id,
			ApiAdminRequestModel request);

		ApiAdminRequestModel MapResponseToRequest(
			ApiAdminResponseModel response);

		JsonPatchDocument<ApiAdminRequestModel> CreatePatch(ApiAdminRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5c324b3af619f77168b931549ab948dc</Hash>
</Codenesium>*/