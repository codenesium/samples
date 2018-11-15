using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostHistoryTypeModelMapper
	{
		ApiPostHistoryTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryTypeClientRequestModel request);

		ApiPostHistoryTypeClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c35d98d9121e9258303a95bc6e86a4cd</Hash>
</Codenesium>*/