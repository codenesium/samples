using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>5ad1a12ff7dfa02eab8c48c40f6c2225</Hash>
</Codenesium>*/