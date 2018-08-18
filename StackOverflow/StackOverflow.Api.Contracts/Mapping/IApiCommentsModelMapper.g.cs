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
    <Hash>7cd38c1fd9015b842f1f92351fa2602f</Hash>
</Codenesium>*/