using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLSpaceSpaceFeatureMapper
	{
		BOSpaceSpaceFeature MapModelToBO(
			int spaceId,
			ApiSpaceSpaceFeatureRequestModel model);

		ApiSpaceSpaceFeatureResponseModel MapBOToModel(
			BOSpaceSpaceFeature boSpaceSpaceFeature);

		List<ApiSpaceSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>396a71b06c38ad5b653afa77d2600d6c</Hash>
</Codenesium>*/