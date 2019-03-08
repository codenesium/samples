using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostHistoryTypesModelMapper
	{
		ApiPostHistoryTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryTypesClientRequestModel request);

		ApiPostHistoryTypesClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryTypesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>bd2e801ed44ff6751adae111e92d4aa9</Hash>
</Codenesium>*/