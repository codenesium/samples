using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiLocationModelMapper
	{
		ApiLocationResponseModel MapRequestToResponse(
			short locationID,
			ApiLocationRequestModel request);

		ApiLocationRequestModel MapResponseToRequest(
			ApiLocationResponseModel response);

		JsonPatchDocument<ApiLocationRequestModel> CreatePatch(ApiLocationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b6ef4a4fd4fd48a85954968227fe6cda</Hash>
</Codenesium>*/