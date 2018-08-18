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
    <Hash>c44ae17e61987d3d97631b6d92bd3e39</Hash>
</Codenesium>*/