using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALTeamMapper
	{
		Team MapModelToEntity(
			int id,
			ApiTeamServerRequestModel model);

		ApiTeamServerResponseModel MapEntityToModel(
			Team item);

		List<ApiTeamServerResponseModel> MapEntityToModel(
			List<Team> items);
	}
}

/*<Codenesium>
    <Hash>e66169a289b2c0240034e366b12e491e</Hash>
</Codenesium>*/