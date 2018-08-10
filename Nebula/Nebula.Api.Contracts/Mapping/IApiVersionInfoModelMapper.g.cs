using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiVersionInfoModelMapper
	{
		ApiVersionInfoResponseModel MapRequestToResponse(
			long version,
			ApiVersionInfoRequestModel request);

		ApiVersionInfoRequestModel MapResponseToRequest(
			ApiVersionInfoResponseModel response);

		JsonPatchDocument<ApiVersionInfoRequestModel> CreatePatch(ApiVersionInfoRequestModel model);
	}
}

/*<Codenesium>
    <Hash>13aba42308bfc76ea236ae27a0a7f56e</Hash>
</Codenesium>*/