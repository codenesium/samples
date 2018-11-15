using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiIllustrationModelMapper
	{
		ApiIllustrationClientResponseModel MapClientRequestToResponse(
			int illustrationID,
			ApiIllustrationClientRequestModel request);

		ApiIllustrationClientRequestModel MapClientResponseToRequest(
			ApiIllustrationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>11980b45ee255b6a7f34fb5de58c3796</Hash>
</Codenesium>*/