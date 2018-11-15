using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLSpaceFeatureMapper
	{
		BOSpaceFeature MapModelToBO(
			int id,
			ApiSpaceFeatureServerRequestModel model);

		ApiSpaceFeatureServerResponseModel MapBOToModel(
			BOSpaceFeature boSpaceFeature);

		List<ApiSpaceFeatureServerResponseModel> MapBOToModel(
			List<BOSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>643f3c3f50194324df126bc0f7d38cf0</Hash>
</Codenesium>*/