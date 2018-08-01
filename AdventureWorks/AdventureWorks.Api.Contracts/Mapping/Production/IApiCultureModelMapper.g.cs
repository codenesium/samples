using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCultureModelMapper
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
    <Hash>2fa2691cc404972704fd9734b23f4fa6</Hash>
</Codenesium>*/