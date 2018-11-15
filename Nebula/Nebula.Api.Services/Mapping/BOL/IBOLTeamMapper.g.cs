using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLTeamMapper
	{
		BOTeam MapModelToBO(
			int id,
			ApiTeamServerRequestModel model);

		ApiTeamServerResponseModel MapBOToModel(
			BOTeam boTeam);

		List<ApiTeamServerResponseModel> MapBOToModel(
			List<BOTeam> items);
	}
}

/*<Codenesium>
    <Hash>c50eb15bfc7deb938bda711408283d66</Hash>
</Codenesium>*/