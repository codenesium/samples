using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiAdminModelMapper
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
    <Hash>682c26ab1646aed39f7e7f596bad28ff</Hash>
</Codenesium>*/