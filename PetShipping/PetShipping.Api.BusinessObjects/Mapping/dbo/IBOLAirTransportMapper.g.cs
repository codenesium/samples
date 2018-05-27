using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLAirTransportMapper
	{
		DTOAirTransport MapModelToDTO(
			int airlineId,
			ApiAirTransportRequestModel model);

		ApiAirTransportResponseModel MapDTOToModel(
			DTOAirTransport dtoAirTransport);

		List<ApiAirTransportResponseModel> MapDTOToModel(
			List<DTOAirTransport> dtos);
	}
}

/*<Codenesium>
    <Hash>95d7512710e4d1722400c5f1fd551e39</Hash>
</Codenesium>*/