using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiCommentsModelMapper
	{
		ApiCommentsResponseModel MapRequestToResponse(
			int id,
			ApiCommentsRequestModel request);

		ApiCommentsRequestModel MapResponseToRequest(
			ApiCommentsResponseModel response);

		JsonPatchDocument<ApiCommentsRequestModel> CreatePatch(ApiCommentsRequestModel model);
	}
}

/*<Codenesium>
    <Hash>176d628fd597522b3a9b4d500cc42be0</Hash>
</Codenesium>*/