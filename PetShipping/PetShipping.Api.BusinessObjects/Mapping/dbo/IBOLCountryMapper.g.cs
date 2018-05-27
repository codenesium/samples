using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLCountryMapper
	{
		DTOCountry MapModelToDTO(
			int id,
			ApiCountryRequestModel model);

		ApiCountryResponseModel MapDTOToModel(
			DTOCountry dtoCountry);

		List<ApiCountryResponseModel> MapDTOToModel(
			List<DTOCountry> dtos);
	}
}

/*<Codenesium>
    <Hash>4e493399aa1e8e33c19437c4b2318327</Hash>
</Codenesium>*/