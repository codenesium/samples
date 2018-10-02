using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiVProductAndDescriptionModelMapper
	{
		ApiVProductAndDescriptionResponseModel MapRequestToResponse(
			string cultureID,
			ApiVProductAndDescriptionRequestModel request);

		ApiVProductAndDescriptionRequestModel MapResponseToRequest(
			ApiVProductAndDescriptionResponseModel response);

		JsonPatchDocument<ApiVProductAndDescriptionRequestModel> CreatePatch(ApiVProductAndDescriptionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9b0523daecf6d4bac5a65da6a7321b58</Hash>
</Codenesium>*/