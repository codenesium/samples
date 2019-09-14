using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALSpaceSpaceFeatureMapper
	{
		SpaceSpaceFeature MapModelToEntity(
			int id,
			ApiSpaceSpaceFeatureServerRequestModel model);

		ApiSpaceSpaceFeatureServerResponseModel MapEntityToModel(
			SpaceSpaceFeature item);

		List<ApiSpaceSpaceFeatureServerResponseModel> MapEntityToModel(
			List<SpaceSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>48eaf05224724cc38da4bbdd4a341a99</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/