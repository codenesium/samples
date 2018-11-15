using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostLinkModelMapper
	{
		ApiPostLinkClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostLinkClientRequestModel request);

		ApiPostLinkClientRequestModel MapClientResponseToRequest(
			ApiPostLinkClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>6d5dd2243d5cf0549c92e73b8058c777</Hash>
</Codenesium>*/