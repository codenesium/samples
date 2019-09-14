using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>fc2942ed81bfa9942bfa43b1ea60e846</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/