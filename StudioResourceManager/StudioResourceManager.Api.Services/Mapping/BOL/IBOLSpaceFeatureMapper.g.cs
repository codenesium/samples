using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>9e02943dd576dee379d32954b0f3cf2c</Hash>
</Codenesium>*/