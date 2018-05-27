using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLStateMapper
	{
		DTOState MapModelToDTO(
			int id,
			ApiStateRequestModel model);

		ApiStateResponseModel MapDTOToModel(
			DTOState dtoState);

		List<ApiStateResponseModel> MapDTOToModel(
			List<DTOState> dtos);
	}
}

/*<Codenesium>
    <Hash>5b613679e440f31c774c2b706255fea1</Hash>
</Codenesium>*/