using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLSpaceFeatureMapper
	{
		BOSpaceFeature MapModelToBO(
			int id,
			ApiSpaceFeatureRequestModel model);

		ApiSpaceFeatureResponseModel MapBOToModel(
			BOSpaceFeature boSpaceFeature);

		List<ApiSpaceFeatureResponseModel> MapBOToModel(
			List<BOSpaceFeature> items);
	}
}

/*<Codenesium>
    <Hash>16a1117edb6a32433606dc249862dbbc</Hash>
</Codenesium>*/