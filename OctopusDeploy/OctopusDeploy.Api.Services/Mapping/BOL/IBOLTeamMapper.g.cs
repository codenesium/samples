using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLTeamMapper
	{
		BOTeam MapModelToBO(
			string id,
			ApiTeamRequestModel model);

		ApiTeamResponseModel MapBOToModel(
			BOTeam boTeam);

		List<ApiTeamResponseModel> MapBOToModel(
			List<BOTeam> items);
	}
}

/*<Codenesium>
    <Hash>73001da4b0f00d73775039f84552a7c3</Hash>
</Codenesium>*/