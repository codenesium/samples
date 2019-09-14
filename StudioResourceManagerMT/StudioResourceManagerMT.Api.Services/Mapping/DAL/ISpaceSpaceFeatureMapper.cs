using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>c24a78e3211a24a01d4d389001032d90</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/