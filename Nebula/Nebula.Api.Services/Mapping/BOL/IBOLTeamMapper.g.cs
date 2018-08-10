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
			ApiTeamRequestModel model);

		ApiTeamResponseModel MapBOToModel(
			BOTeam boTeam);

		List<ApiTeamResponseModel> MapBOToModel(
			List<BOTeam> items);
	}
}

/*<Codenesium>
    <Hash>44fb51df1c6970e6d5ab1b80066387b8</Hash>
</Codenesium>*/