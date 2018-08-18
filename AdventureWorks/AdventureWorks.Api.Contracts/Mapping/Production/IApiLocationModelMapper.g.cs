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
    <Hash>c8744da778073bb9201e3fee216404dc</Hash>
</Codenesium>*/