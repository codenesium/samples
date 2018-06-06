using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLSpaceXSpaceFeatureMapper
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
    <Hash>e5bb7ed81e5b1c06edc3c5f2fa34e855</Hash>
</Codenesium>*/