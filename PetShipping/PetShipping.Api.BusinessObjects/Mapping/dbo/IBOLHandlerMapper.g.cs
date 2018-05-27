using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLHandlerMapper
	{
		DTOHandler MapModelToDTO(
			int id,
			ApiHandlerRequestModel model);

		ApiHandlerResponseModel MapDTOToModel(
			DTOHandler dtoHandler);

		List<ApiHandlerResponseModel> MapDTOToModel(
			List<DTOHandler> dtos);
	}
}

/*<Codenesium>
    <Hash>2c1489c9d0b8ea5fe0d417c40c01e8ca</Hash>
</Codenesium>*/