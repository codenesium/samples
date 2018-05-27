using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLSpaceFeatureMapper
	{
		DTOSpaceFeature MapModelToDTO(
			int id,
			ApiSpaceFeatureRequestModel model);

		ApiSpaceFeatureResponseModel MapDTOToModel(
			DTOSpaceFeature dtoSpaceFeature);

		List<ApiSpaceFeatureResponseModel> MapDTOToModel(
			List<DTOSpaceFeature> dtos);
	}
}

/*<Codenesium>
    <Hash>2d9e8a286bc21741608da35940377b14</Hash>
</Codenesium>*/