using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiCommentsModelMapper
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
    <Hash>0a8e116a8bdb38ae465c50697183892e</Hash>
</Codenesium>*/