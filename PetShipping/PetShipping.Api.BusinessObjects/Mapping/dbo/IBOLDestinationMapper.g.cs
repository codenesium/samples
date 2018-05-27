using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLDestinationMapper
	{
		DTODestination MapModelToDTO(
			int id,
			ApiDestinationRequestModel model);

		ApiDestinationResponseModel MapDTOToModel(
			DTODestination dtoDestination);

		List<ApiDestinationResponseModel> MapDTOToModel(
			List<DTODestination> dtos);
	}
}

/*<Codenesium>
    <Hash>057e32d6a71260745ce7ab452e4d59af</Hash>
</Codenesium>*/