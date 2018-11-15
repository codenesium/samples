using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiCompositePrimaryKeyModelMapper
	{
		ApiCompositePrimaryKeyClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCompositePrimaryKeyClientRequestModel request);

		ApiCompositePrimaryKeyClientRequestModel MapClientResponseToRequest(
			ApiCompositePrimaryKeyClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2dc61b8fbdb0d17fccf4aab1369cfbd5</Hash>
</Codenesium>*/