using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiTeamModelMapper
	{
		ApiTeamClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeamClientRequestModel request);

		ApiTeamClientRequestModel MapClientResponseToRequest(
			ApiTeamClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b1ad59f79d9a6fb01d0618b26da2c72e</Hash>
</Codenesium>*/