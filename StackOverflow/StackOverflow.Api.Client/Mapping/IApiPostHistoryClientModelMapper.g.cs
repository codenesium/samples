using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostHistoryModelMapper
	{
		ApiPostHistoryClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryClientRequestModel request);

		ApiPostHistoryClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7928e9d20487195d4f2c1bfb41cbad9f</Hash>
</Codenesium>*/