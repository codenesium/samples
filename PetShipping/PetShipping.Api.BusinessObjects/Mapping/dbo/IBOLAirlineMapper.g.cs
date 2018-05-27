using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLAirlineMapper
	{
		DTOAirline MapModelToDTO(
			int id,
			ApiAirlineRequestModel model);

		ApiAirlineResponseModel MapDTOToModel(
			DTOAirline dtoAirline);

		List<ApiAirlineResponseModel> MapDTOToModel(
			List<DTOAirline> dtos);
	}
}

/*<Codenesium>
    <Hash>2d1ad9d44efe230d58914db3d8d6ca09</Hash>
</Codenesium>*/