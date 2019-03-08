using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiCommentsModelMapper
	{
		ApiCommentsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCommentsClientRequestModel request);

		ApiCommentsClientRequestModel MapClientResponseToRequest(
			ApiCommentsClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1d7d514ec9abcbbed159b0b0cf0be40e</Hash>
</Codenesium>*/