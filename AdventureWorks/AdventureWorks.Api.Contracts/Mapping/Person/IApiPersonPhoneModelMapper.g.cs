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
    <Hash>4d42c9cd7939001c81637bdd51cd5338</Hash>
</Codenesium>*/