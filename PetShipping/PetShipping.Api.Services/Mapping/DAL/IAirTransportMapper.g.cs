using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALAirTransportMapper
	{
		AirTransport MapModelToEntity(
			int airlineId,
			ApiAirTransportServerRequestModel model);

		ApiAirTransportServerResponseModel MapEntityToModel(
			AirTransport item);

		List<ApiAirTransportServerResponseModel> MapEntityToModel(
			List<AirTransport> items);
	}
}

/*<Codenesium>
    <Hash>56c0650e5addf37baff438cfb0b9340d</Hash>
</Codenesium>*/