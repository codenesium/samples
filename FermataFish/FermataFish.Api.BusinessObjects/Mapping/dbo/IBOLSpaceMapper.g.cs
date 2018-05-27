using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLSpaceMapper
	{
		DTOSpace MapModelToDTO(
			int id,
			ApiSpaceRequestModel model);

		ApiSpaceResponseModel MapDTOToModel(
			DTOSpace dtoSpace);

		List<ApiSpaceResponseModel> MapDTOToModel(
			List<DTOSpace> dtos);
	}
}

/*<Codenesium>
    <Hash>0afe0ecf3677547b9d23d659af63eb39</Hash>
</Codenesium>*/