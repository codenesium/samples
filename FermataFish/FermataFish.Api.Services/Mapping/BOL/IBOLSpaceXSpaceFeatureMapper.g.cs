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
    <Hash>4aff22837671267d4b07891ed6a98c69</Hash>
</Codenesium>*/