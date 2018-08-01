using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLSpaceFeatureMapper
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
    <Hash>83a64fbb98a90ee4c57a51edb56bc250</Hash>
</Codenesium>*/