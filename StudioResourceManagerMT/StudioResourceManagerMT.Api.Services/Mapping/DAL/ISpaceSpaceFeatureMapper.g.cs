using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALSpaceSpaceFeatureMapper
	{
		SpaceSpaceFeature MapModelToEntity(
			int spaceId,
			ApiSpaceSpaceFeatureServerRequestModel model);

		ApiSpaceSpaceFeatureServerResponseModel MapEntityToModel(
			SpaceSpaceFeature item);

		List<ApiSpaceSpaceFeatureServerResponseModel> MapEntityToModel(
			List<SpaceSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>434385e05f2baffc59c3029551b1fd70</Hash>
</Codenesium>*/