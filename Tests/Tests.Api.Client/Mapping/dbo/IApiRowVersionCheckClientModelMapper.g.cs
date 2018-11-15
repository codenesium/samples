using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiRowVersionCheckModelMapper
	{
		ApiRowVersionCheckClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRowVersionCheckClientRequestModel request);

		ApiRowVersionCheckClientRequestModel MapClientResponseToRequest(
			ApiRowVersionCheckClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>15cb5f22071c158ceddb6198a8390c23</Hash>
</Codenesium>*/