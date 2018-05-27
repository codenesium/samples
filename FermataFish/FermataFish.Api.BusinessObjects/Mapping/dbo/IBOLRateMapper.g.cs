using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLRateMapper
	{
		DTORate MapModelToDTO(
			int id,
			ApiRateRequestModel model);

		ApiRateResponseModel MapDTOToModel(
			DTORate dtoRate);

		List<ApiRateResponseModel> MapDTOToModel(
			List<DTORate> dtos);
	}
}

/*<Codenesium>
    <Hash>ff9e5b5333776c7d5237754778063b07</Hash>
</Codenesium>*/