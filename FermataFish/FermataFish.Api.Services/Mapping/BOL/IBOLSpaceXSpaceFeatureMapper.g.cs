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
			List<BOSpaceXSpaceFeature> bos);
	}
}

/*<Codenesium>
    <Hash>4711379f3376d36146758e31c2734e3d</Hash>
</Codenesium>*/