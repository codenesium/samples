using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLSpaceSpaceFeatureMapper
	{
		BOSpaceSpaceFeature MapModelToBO(
			int id,
			ApiSpaceSpaceFeatureRequestModel model);

		ApiSpaceSpaceFeatureResponseModel MapBOToModel(
			BOSpaceSpaceFeature boSpaceSpaceFeature);

		List<ApiSpaceSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>0fa650b7ad62e78318d8cdba9e732e34</Hash>
</Codenesium>*/