using NebulaNS.Api.Contracts;
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
    <Hash>dda587469c821f883f686b7fc6cf11dd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/