using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALRateMapper
	{
		Rate MapModelToEntity(
			int id,
			ApiRateServerRequestModel model);

		ApiRateServerResponseModel MapEntityToModel(
			Rate item);

		List<ApiRateServerResponseModel> MapEntityToModel(
			List<Rate> items);
	}
}

/*<Codenesium>
    <Hash>f53d2dd851d930b1300580b42f2b4849</Hash>
</Codenesium>*/