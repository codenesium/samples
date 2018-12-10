using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiClaspModelMapper
	{
		ApiClaspClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClaspClientRequestModel request);

		ApiClaspClientRequestModel MapClientResponseToRequest(
			ApiClaspClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>bfe00c9b8bdb369ce51286c78c538e8b</Hash>
</Codenesium>*/