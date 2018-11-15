using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiMessageModelMapper
	{
		ApiMessageClientResponseModel MapClientRequestToResponse(
			int messageId,
			ApiMessageClientRequestModel request);

		ApiMessageClientRequestModel MapClientResponseToRequest(
			ApiMessageClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>85c5cc38836b9767bb75276bb96bd487</Hash>
</Codenesium>*/