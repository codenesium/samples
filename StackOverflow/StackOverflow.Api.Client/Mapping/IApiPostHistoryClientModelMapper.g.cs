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
    <Hash>7199977f6038a8571e1d0486cdc9d901</Hash>
</Codenesium>*/