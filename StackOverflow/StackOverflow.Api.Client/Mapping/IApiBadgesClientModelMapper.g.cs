using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiBadgesModelMapper
	{
		ApiBadgesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBadgesClientRequestModel request);

		ApiBadgesClientRequestModel MapClientResponseToRequest(
			ApiBadgesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>86e7281f3bb6283fa27fc4db2ea68bc3</Hash>
</Codenesium>*/