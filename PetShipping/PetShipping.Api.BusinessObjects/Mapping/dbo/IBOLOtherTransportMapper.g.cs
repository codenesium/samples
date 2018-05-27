using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLOtherTransportMapper
	{
		DTOOtherTransport MapModelToDTO(
			int id,
			ApiOtherTransportRequestModel model);

		ApiOtherTransportResponseModel MapDTOToModel(
			DTOOtherTransport dtoOtherTransport);

		List<ApiOtherTransportResponseModel> MapDTOToModel(
			List<DTOOtherTransport> dtos);
	}
}

/*<Codenesium>
    <Hash>2d5026661923fe43057181cb4dd5137a</Hash>
</Codenesium>*/