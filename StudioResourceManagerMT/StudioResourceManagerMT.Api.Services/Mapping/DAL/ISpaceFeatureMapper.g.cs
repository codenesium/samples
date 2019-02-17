using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALSpaceFeatureMapper
	{
		SpaceFeature MapModelToEntity(
			int id,
			ApiSpaceFeatureServerRequestModel model);

		ApiSpaceFeatureServerResponseModel MapEntityToModel(
			SpaceFeature item);

		List<ApiSpaceFeatureServerResponseModel> MapEntityToModel(
			List<SpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>c025c4024bfbe9ae6626d0b5a10234bf</Hash>
</Codenesium>*/