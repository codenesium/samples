using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCultureModelMapper
	{
		ApiCultureResponseModel MapRequestToResponse(
			string cultureID,
			ApiCultureRequestModel request);

		ApiCultureRequestModel MapResponseToRequest(
			ApiCultureResponseModel response);

		JsonPatchDocument<ApiCultureRequestModel> CreatePatch(ApiCultureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bc79ed0d842c0a56e9c5ce2c357546ec</Hash>
</Codenesium>*/