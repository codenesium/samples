using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

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
    <Hash>db51b71e98db3f6a66dfae53383d0d80</Hash>
</Codenesium>*/