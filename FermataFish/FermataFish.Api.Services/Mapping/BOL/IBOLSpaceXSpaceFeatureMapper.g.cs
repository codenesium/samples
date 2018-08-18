using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLSpaceXSpaceFeatureMapper
	{
		BOSpaceXSpaceFeature MapModelToBO(
			int id,
			ApiSpaceXSpaceFeatureRequestModel model);

		ApiSpaceXSpaceFeatureResponseModel MapBOToModel(
			BOSpaceXSpaceFeature boSpaceXSpaceFeature);

		List<ApiSpaceXSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceXSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>89e52e6dfc3314cbfb2fe93f98d02b3b</Hash>
</Codenesium>*/