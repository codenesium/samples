using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>4a81db2f08edc28c6c858fbcfda1ba7c</Hash>
</Codenesium>*/