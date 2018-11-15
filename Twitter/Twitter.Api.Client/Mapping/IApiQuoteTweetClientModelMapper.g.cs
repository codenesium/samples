using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiQuoteTweetModelMapper
	{
		ApiQuoteTweetClientResponseModel MapClientRequestToResponse(
			int quoteTweetId,
			ApiQuoteTweetClientRequestModel request);

		ApiQuoteTweetClientRequestModel MapClientResponseToRequest(
			ApiQuoteTweetClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4cd82b5eb1b640b95554cd7464ce551a</Hash>
</Codenesium>*/