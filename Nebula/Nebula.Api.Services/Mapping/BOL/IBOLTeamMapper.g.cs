using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLTeamMapper
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
    <Hash>0fa076e792a18cbfd87f1b6d51f1b87a</Hash>
</Codenesium>*/