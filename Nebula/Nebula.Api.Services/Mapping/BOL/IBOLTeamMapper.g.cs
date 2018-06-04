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
			List<BOTeam> bos);
	}
}

/*<Codenesium>
    <Hash>68ee08cdd04f9758749691e9d1cf35a7</Hash>
</Codenesium>*/