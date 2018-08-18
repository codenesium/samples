using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPersonPhoneModelMapper
	{
		ApiPersonPhoneResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonPhoneRequestModel request);

		ApiPersonPhoneRequestModel MapResponseToRequest(
			ApiPersonPhoneResponseModel response);

		JsonPatchDocument<ApiPersonPhoneRequestModel> CreatePatch(ApiPersonPhoneRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e9cd270a406ae01876d72c9b2e56762b</Hash>
</Codenesium>*/