using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLStudioMapper
	{
		DTOStudio MapModelToDTO(
			int id,
			ApiStudioRequestModel model);

		ApiStudioResponseModel MapDTOToModel(
			DTOStudio dtoStudio);

		List<ApiStudioResponseModel> MapDTOToModel(
			List<DTOStudio> dtos);
	}
}

/*<Codenesium>
    <Hash>84f5c169c1f1d3059223b86e63d10139</Hash>
</Codenesium>*/