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
    <Hash>64287affd03cb7f4fa9e92764566f3cb</Hash>
</Codenesium>*/