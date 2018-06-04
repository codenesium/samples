using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
			List<BOSpaceFeature> bos);
	}
}

/*<Codenesium>
    <Hash>137f73965507d30f37307e591738498d</Hash>
</Codenesium>*/