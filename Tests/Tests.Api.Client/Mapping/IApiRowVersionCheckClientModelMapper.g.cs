using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

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
    <Hash>5c25f32b52750057b44c33894b8b26f0</Hash>
</Codenesium>*/