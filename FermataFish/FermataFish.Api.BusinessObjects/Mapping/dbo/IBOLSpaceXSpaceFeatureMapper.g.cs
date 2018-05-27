using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLSpaceXSpaceFeatureMapper
	{
		DTOSpaceXSpaceFeature MapModelToDTO(
			int id,
			ApiSpaceXSpaceFeatureRequestModel model);

		ApiSpaceXSpaceFeatureResponseModel MapDTOToModel(
			DTOSpaceXSpaceFeature dtoSpaceXSpaceFeature);

		List<ApiSpaceXSpaceFeatureResponseModel> MapDTOToModel(
			List<DTOSpaceXSpaceFeature> dtos);
	}
}

/*<Codenesium>
    <Hash>34b001529bd8595e03dda658a5789354</Hash>
</Codenesium>*/